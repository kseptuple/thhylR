﻿using thhylR.Games;

namespace thhylR.Common
{
    public static class KeyAndFrameData
    {
        public static void InitFrameCountAndFPS(TouhouReplay replay)
        {
            GameOffsets gameData = replay.GameData;
            if (gameData.StageSetting.KeyData.KeyDataVersion == 1)
            {
                replay.TotalFrameCount = 0;
                double totalFPS = 0d;
                var FPSDataGetter = getKeyDataGetter(gameData.StageSetting.KeyData.FPSSize);
                var FPSStart = gameData.StageSetting.KeyData.FirstFPSFrameIsNullFrame ? gameData.StageSetting.KeyData.FPSSize : 0;
                foreach (var stage in replay.Stages)
                {
                    if (stage.KeyData.Length > 2 * gameData.StageSetting.KeySizeData)
                    {
                        int lengthPos = stage.KeyData.Length - 2 * gameData.StageSetting.KeySizeData;
                        int length = BitConverter.ToInt32(replay.RawData, stage.KeyData.Offset + lengthPos) - 1;
                        stage.FrameCount = length;
                        replay.TotalFrameCount += length;
                        if (stage.FPSData != null)
                        {
                            int lastFPSFrames = stage.FrameCount % 30;
                            double stageTotalFPS = 0d;
                            for (int i = FPSStart; i < stage.FPSData.Length; i+= gameData.StageSetting.KeyData.FPSSize)
                            {
                                int fps = FPSDataGetter(replay.RawData, stage.FPSData.Offset + i);
                                if (i != stage.FPSData.Length - 1)
                                {
                                    stageTotalFPS += fps * 30;
                                }
                                else
                                {
                                    stageTotalFPS += fps * lastFPSFrames;
                                }
                            }
                            totalFPS += stageTotalFPS;
                            stage.CalculatedSlowRate = 1 - stageTotalFPS / stage.FrameCount / 60d;
                        }
                    }
                }
                replay.CalculatedTotalSlowRate = 1 - totalFPS / replay.TotalFrameCount / 60d;
            }
            else if (gameData.StageSetting.KeyData.KeyDataVersion >= 2)
            {
                replay.TotalFrameCount = 0;
                double totalFPS = 0d;
                var FPSDataGetter = getKeyDataGetter(gameData.StageSetting.KeyData.FPSSize);
                var FPSStart = gameData.StageSetting.KeyData.FirstFPSFrameIsNullFrame ? gameData.StageSetting.KeyData.FPSSize : 0;
                for (int i = 0; i < replay.Stages.Count; i++)
                {
                    var requireCountFrame = !gameData.StageSetting.IsVSGame || i < replay.Stages.Count / 2;
                    var stage = replay.Stages[i];
                    stage.FrameCount = stage.KeyData.Length / gameData.StageSetting.KeySizeData;
                    if (gameData.StageSetting.KeyData.FirstFrameIsNullFrame)
                    {
                        stage.FrameCount--;
                    }
                    if (gameData.StageSetting.KeyData.HasTerminateMark)
                    {
                        int lastKey = stage.KeyData.Length - gameData.StageSetting.KeySizeData;
                        int lastKeyStart = stage.KeyData.Offset + lastKey;
                        byte[] lastKeyByte = replay.RawData[lastKeyStart..(lastKeyStart + gameData.StageSetting.KeySizeData)];
                        bool hasTerminateMark = true;
                        foreach (var item in lastKeyByte)
                        {
                            if (item != 0xFF)
                            {
                                hasTerminateMark = false;
                                break;
                            }
                        }
                        if (hasTerminateMark)
                        {
                            stage.FrameCount--;
                        }
                    }
                    if (requireCountFrame)
                    {
                        replay.TotalFrameCount += stage.FrameCount;
                    }

                    int lastFPSFrames = stage.FrameCount % 30;
                    double stageTotalFPS = 0d;
                    for (int j = FPSStart; j < stage.FPSData.Length; j += gameData.StageSetting.KeyData.FPSSize)
                    {
                        int fps = FPSDataGetter(replay.RawData, stage.FPSData.Offset + j);
                        if (j != stage.FPSData.Length - 1)
                        {
                            stageTotalFPS += fps * 30;
                        }
                        else
                        {
                            stageTotalFPS += fps * lastFPSFrames;
                        }
                    }
                    if (requireCountFrame)
                    {
                        totalFPS += stageTotalFPS;
                    }
                    stage.CalculatedSlowRate = 1 - stageTotalFPS / stage.FrameCount / 60d;
                }
                replay.CalculatedTotalSlowRate = 1 - totalFPS / replay.TotalFrameCount / 60d;
            }
        }

        public static void ReadKeys(TouhouReplay replay, int stageIndex)
        {
            if (stageIndex < 0 || stageIndex >= replay.Stages.Count) return;
            if (replay.Stages[stageIndex].KeyList != null && replay.Stages[stageIndex].KeyList.Count > 0) return;
            List<int> keyIndices = new List<int>();
            List<int> keyFlags = new List<int>();
            replay.Stages[stageIndex].KeyList = new List<string[]>();
            replay.Stages[stageIndex].ArrowKeyList = new List<byte>();
            replay.Stages[stageIndex].HasConflictKeys = false;
            Func<byte[], int, int> getKeyData = null;
            GameOffsets gameData = replay.GameData;
            var keyDataSettings = gameData.StageSetting.KeyData;
            int[] arrowBits = new int[4];
            byte[] arrowBitNum = new byte[4];
            for (int i = 0; i < keyDataSettings.KeyNames.Count; i++)
            {
                if (!string.IsNullOrEmpty(keyDataSettings.KeyNames[i]))
                {
                    keyIndices.Add(i);
                    keyFlags.Add(1 << i);
                    switch (keyDataSettings.KeyNames[i])
                    {
                        case "↑":
                            arrowBits[0] = i;
                            arrowBitNum[0] = 1;
                            break;
                        case "↓":
                            arrowBits[1] = i;
                            arrowBitNum[1] = 2;
                            break;
                        case "←":
                            arrowBits[2] = i;
                            arrowBitNum[2] = 4;
                            break;
                        case "→":
                            arrowBits[3] = i;
                            arrowBitNum[3] = 8;
                            break;
                    }
                }
            }

            getKeyData = getKeyDataGetter(keyDataSettings.KeySize);
            if (getKeyData == null) return;
            var keyDataOffsets = replay.Stages[stageIndex].KeyData;

            var totalKeys = keyDataSettings.KeyNames.Count;

            int globalOffset = keyDataOffsets.Offset;

            int[] lastArrowCount = new int[4] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };

            if (keyDataSettings.KeyDataVersion == 1)
            {
                int currentFrame = 1;
                string[] currentFrameKeyNames = null;
                byte currentArrowKey = 0;
                int i = globalOffset;
                int targetFrame = 0;
                int secondFrame = BitConverter.ToInt32(replay.RawData, globalOffset + gameData.StageSetting.KeySizeData);
                if (secondFrame == 1)
                {
                    targetFrame = 1;
                    i += gameData.StageSetting.KeySizeData;
                }

                int totalFrames = replay.Stages[stageIndex].FrameCount;
                do
                {
                    if (targetFrame <= currentFrame)
                    {
                        lastArrowCount[0] = lastArrowCount[1] = lastArrowCount[2] = lastArrowCount[3] = int.MaxValue;
                        int keyDataInt = getKeyData(replay.RawData, i + 4);
                        currentFrameKeyNames = new string[totalKeys];
                        currentArrowKey = 0;
                        i += gameData.StageSetting.KeySizeData;
                        targetFrame = BitConverter.ToInt32(replay.RawData, i);
                        for (int j = 0; j < keyIndices.Count; j++)
                        {
                            if ((keyDataInt & keyFlags[j]) != 0)
                            {
                                currentFrameKeyNames[keyIndices[j]] = keyDataSettings.KeyNames[keyIndices[j]];
                                for (int k = 0; k < 4; k++)
                                {
                                    if (keyIndices[j] == arrowBits[k])
                                    {
                                        currentArrowKey |= arrowBitNum[k];
                                    }
                                }
                            }
                        }
                    }
                    if ((currentArrowKey & 3) == 3 || (currentArrowKey & 12) == 12)
                        replay.Stages[stageIndex].HasConflictKeys = true;
                    currentFrame++;
                    replay.Stages[stageIndex].KeyList.Add(currentFrameKeyNames);
                    replay.Stages[stageIndex].ArrowKeyList.Add(currentArrowKey);

                } while (currentFrame <= totalFrames);
            }
            else
            {
                if (keyDataSettings.FirstFrameIsNullFrame)
                {
                    globalOffset += gameData.StageSetting.KeySizeData;
                }
                var keyDataEnd = globalOffset + gameData.StageSetting.KeySizeData * replay.Stages[stageIndex].FrameCount;
                for (int i = globalOffset; i < keyDataEnd; i += gameData.StageSetting.KeySizeData)
                {
                    lastArrowCount[0] = lastArrowCount[1] = lastArrowCount[2] = lastArrowCount[3] = int.MaxValue;
                    int keyDataInt = getKeyData(replay.RawData, i);
                    string[] currentFrameKeyNames = new string[totalKeys];
                    byte currentArrowKey = 0;
                    for (int j = 0; j < keyIndices.Count; j++)
                    {
                        if ((keyDataInt & keyFlags[j]) != 0)
                        {
                            currentFrameKeyNames[keyIndices[j]] = keyDataSettings.KeyNames[keyIndices[j]];
                            for (int k = 0; k < 4; k++)
                            {
                                if (keyIndices[j] == arrowBits[k])
                                {
                                    currentArrowKey |= arrowBitNum[k];
                                }
                            }
                        }
                    }
                    if ((currentArrowKey & 3) == 3 || (currentArrowKey & 12) == 12)
                        replay.Stages[stageIndex].HasConflictKeys = true;
                    replay.Stages[stageIndex].KeyList.Add(currentFrameKeyNames);
                    replay.Stages[stageIndex].ArrowKeyList.Add(currentArrowKey);
                }
            }
            var FPSDataGetter = getKeyDataGetter(gameData.StageSetting.KeyData.FPSSize);
            var FPSStart = gameData.StageSetting.KeyData.FirstFPSFrameIsNullFrame ? gameData.StageSetting.KeyData.FPSSize : 0;

            if (gameData.StageSetting.FPSStartData != -1 || gameData.ReplayStructVersion != 1)
            {
                replay.Stages[stageIndex].FPSList = new List<int>();
                int frameCount = replay.Stages[stageIndex].FrameCount;
                int remainFrame = frameCount % 30;
                var frameDataOffsets = replay.Stages[stageIndex].FPSData;
                var frameDataEnd = frameDataOffsets.Offset + frameDataOffsets.Length;

                for (int i = frameDataOffsets.Offset + FPSStart; i < frameDataEnd; i+= gameData.StageSetting.KeyData.FPSSize)
                {
                    int currentFrameFPS = FPSDataGetter(replay.RawData, i);
                    int count = i != frameDataEnd ? 30 : remainFrame;
                    for (int j = 0; j < count; j++)
                    {
                        replay.Stages[stageIndex].FPSList.Add(currentFrameFPS);
                    }
                }
            }
        }

        private static Func<byte[], int, int> getKeyDataGetter(int keyDataSize)
        {
            Func<byte[], int, int> result = null;
            if (keyDataSize == 1)
            {
                result = (input, offset) => input[offset];
            }
            else if (keyDataSize == 2)
            {
                result = (input, offset) => BitConverter.ToInt16(input, offset);
            }
            else if (keyDataSize == 4)
            {
                result = (input, offset) => BitConverter.ToInt32(input, offset);
            }
            return result;
        }

        private static List<ExtractedKey> extractedKeys = new List<ExtractedKey>();

        static KeyAndFrameData()
        {
            for (int i = 0; i < 16; i++)
            {
                ExtractedKey extractedKey = new ExtractedKey();
                extractedKey.SingleKeyPressed = new bool[4];
                int n = i;
                for (int j = 0; j < 4; j++)
                {
                    if ((n & 1) != 0)
                    {
                        extractedKey.KeyCount++;
                        extractedKey.SingleKeyPressed[j] = true;
                    }
                    else
                    {
                        extractedKey.SingleKeyPressed[j] = false;
                    }
                    n >>= 1;
                }
                extractedKeys.Add(extractedKey);
            }
        }

        public static FullKeyStats GetKeyStats(List<byte> arrowKeyList, bool hasConflictKey)
        {
            KeyStats keyboard = new KeyStats(KeyType.Keyboard);
            KeyStats controller = new KeyStats(KeyType.Controller);
            FullKeyStats result = new FullKeyStats();
            result.TotalFrames = arrowKeyList.Count;
            result.KeyboardKey = keyboard;
            result.ControllerKey = controller;

            byte[] paddedArrowKeys = new byte[arrowKeyList.Count + 3];
            arrowKeyList.CopyTo(paddedArrowKeys, 0);

            Queue<byte> keyQueue = new Queue<byte>();
            keyQueue.EnsureCapacity(61);
            for (int i = 0; i < 60; i++)
            {
                keyQueue.Enqueue(0);
            }
            int[] keyboardArrowLengthCounter = [0, 0, 0, 0];
            int controllerArrowLengthCounter = 0;

            int[] keyboardArrowCurrentSum = [0, 0, 0, 0];
            int controllerArrowCurrentSum = 0;

            byte lastKey = 0;
            byte[] currentVirtual = [0, 0, 0, 0];

            for (int i = 0; i < paddedArrowKeys.Length - 3; i++)
            {
                byte currentKey = paddedArrowKeys[i];
                byte keyToQueue = 0;

                var tmpKey = extractedKeys[currentKey];

                for (int j = 0; j < tmpKey.SingleKeyPressed.Length; j++)
                {
                    if (tmpKey.SingleKeyPressed[j])
                    {
                        keyboardArrowLengthCounter[j]++;
                    }
                    else
                    {
                        int keyCount = keyboardArrowLengthCounter[j];
                        if (keyCount > 0)
                        {
                            keyboard.TotalKeyLength += keyCount;
                            keyboard.TotalKeys++;
                            if (keyCount <= 3)
                            {
                                keyboard.QuickKeyPressCount[keyCount - 1]++;
                            }
                            keyboardArrowLengthCounter[j] = 0;
                        }
                    }
                }

                byte tmpVirtualKey = 0;
                for (int j = 0; j < 4; j++)
                {
                    tmpVirtualKey |= paddedArrowKeys[i + j];
                    currentVirtual[j] = (byte)(currentVirtual[j] & (~lastKey | currentKey));
                    if ((~currentVirtual[j] & currentKey) != 0)
                    {
                        keyboardArrowCurrentSum[j]++;
                        keyToQueue |= 1;
                        currentVirtual[j] = tmpVirtualKey;
                    }
                    keyToQueue <<= 1;
                }

                if (!hasConflictKey)
                {
                    if (lastKey == currentKey && currentKey != 0)
                    {
                        controllerArrowLengthCounter++;
                    }
                    else
                    {
                        int keyCount = controllerArrowLengthCounter;
                        if (keyCount > 0)
                        {
                            controller.TotalKeyLength += keyCount;
                            controller.TotalKeys++;
                            if (keyCount <= 3)
                            {
                                controller.QuickKeyPressCount[keyCount - 1]++;
                            }
                            controllerArrowLengthCounter = 0;
                        }
                        if (currentKey != 0)
                        {
                            controllerArrowCurrentSum++;
                            keyToQueue |= 1;
                        }
                    }
                }

                keyQueue.Enqueue(keyToQueue);
                lastKey = currentKey;

                byte keyDequeue = keyQueue.Dequeue();
                if (!hasConflictKey)
                {
                    if ((keyDequeue & 1) != 0)
                    {
                        controllerArrowCurrentSum--;
                    }
                }
                controller.KeyPressCount[0].Add(controllerArrowCurrentSum);
                for (int j = 3; j >= 0; j--)
                {
                    keyDequeue >>= 1;
                    if ((keyDequeue & 1) != 0)
                    {
                        keyboardArrowCurrentSum[j]--;
                    }
                    keyboard.KeyPressCount[j].Add(keyboardArrowCurrentSum[j]);
                }
            }

            if (keyboard.TotalKeys == 0)
            {
                keyboard.AverageKeyLength = 0.0;
            }
            else
            {
                keyboard.AverageKeyLength = ((double)keyboard.TotalKeyLength) / keyboard.TotalKeys;
            }

            if (controller.TotalKeys == 0)
            {
                controller.AverageKeyLength = 0.0;
            }
            else
            {
                controller.AverageKeyLength = ((double)controller.TotalKeyLength) / controller.TotalKeys;
            }

            return result;
        }

        private class ExtractedKey
        {
            public int KeyCount { get; set; }
            public bool[] SingleKeyPressed { get; set; }
        }
    }
}
