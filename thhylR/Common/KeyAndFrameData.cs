﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thhylR.Games;
using YamlDotNet.Serialization.BufferedDeserialization;

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
                foreach (var stage in replay.Stages)
                {
                    if (stage.KeyData.Length > 2 * gameData.StageSetting.KeySizeData)
                    {
                        int lengthPos = stage.KeyData.Length - 2 * gameData.StageSetting.KeySizeData;
                        int length = BitConverter.ToInt32(replay.RawData, stage.KeyData.Offset + lengthPos) - 1;
                        stage.FrameCount = length;
                        replay.TotalFrameCount += length;
                    }
                }
            }
            else if (gameData.StageSetting.KeyData.KeyDataVersion >= 2)
            {
                replay.TotalFrameCount = 0;
                double totalFPS = 0d;
                foreach (var stage in replay.Stages)
                {
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
                    replay.TotalFrameCount += stage.FrameCount;

                    int lastFPSFrames = stage.FrameCount % 30;
                    double stageTotalFPS = 0d;
                    for (int i = 0; i < stage.FPSData.Length; i++)
                    {
                        int fps = replay.RawData[stage.FPSData.Offset + i];
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
            Func<byte[], int, int> getKeyData = null;
            var keyDataSettings = replay.GameData.StageSetting.KeyData;
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
            if (keyDataSettings.KeySize == 1)
            {
                getKeyData = (input, offset) => input[offset];
            }
            else if (keyDataSettings.KeySize == 2)
            {
                getKeyData = (input, offset) => BitConverter.ToInt16(input, offset);
            }
            else if (keyDataSettings.KeySize == 4)
            {
                getKeyData = (input, offset) => BitConverter.ToInt32(input, offset);
            }
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
                int secondFrame = BitConverter.ToInt32(replay.RawData, globalOffset + replay.GameData.StageSetting.KeySizeData);
                if (secondFrame == 1)
                {
                    targetFrame = 1;
                    i += replay.GameData.StageSetting.KeySizeData;
                }

                int totalFrames = replay.Stages[stageIndex].FrameCount;
                do
                {
                    if (targetFrame <= currentFrame)
                    {
                        lastArrowCount[0] = lastArrowCount[1] = lastArrowCount[2] = lastArrowCount[3] = int.MaxValue;
                        int keyDataInt = getKeyData(replay.RawData, i + 4);
                        currentFrameKeyNames = new string[totalKeys];
                        i += replay.GameData.StageSetting.KeySizeData;
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
                    currentFrame++;
                    replay.Stages[stageIndex].KeyList.Add(currentFrameKeyNames);
                    replay.Stages[stageIndex].ArrowKeyList.Add(currentArrowKey);

                } while (currentFrame <= totalFrames);
            }
            else
            {
                var keyDataEnd = keyDataOffsets.Offset + keyDataOffsets.Length;
                if (keyDataSettings.FirstFrameIsNullFrame)
                {
                    globalOffset += replay.GameData.StageSetting.KeySizeData;
                }
                for (int i = globalOffset; i < keyDataEnd; i += replay.GameData.StageSetting.KeySizeData)
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

                    replay.Stages[stageIndex].KeyList.Add(currentFrameKeyNames);
                    replay.Stages[stageIndex].ArrowKeyList.Add(currentArrowKey);
                }
            }

            if (replay.GameData.StageSetting.FPSStartData != -1 || replay.GameData.ReplayStructVersion != 1)
            {
                replay.Stages[stageIndex].FPSList = new List<int>();
                int frameCount = replay.Stages[stageIndex].FrameCount;
                int remainFrame = frameCount % 30;
                var frameDataOffsets = replay.Stages[stageIndex].FPSData;
                var frameDataEnd = frameDataOffsets.Offset + frameDataOffsets.Length;

                for (int i = frameDataOffsets.Offset; i < frameDataEnd; i++)
                {
                    int currentFrameFPS = replay.RawData[i];
                    int count = i != frameDataEnd ? 30 : remainFrame;
                    for (int j = 0; j < count; j++)
                    {
                        replay.Stages[stageIndex].FPSList.Add(currentFrameFPS);
                    }
                }
            }
        }

        private static List<ExtractedKey> extractedKeys = new List<ExtractedKey>();

        static KeyAndFrameData()
        {
            for (int i = 0; i < 16; i++)
            {
                ExtractedKey extractedKey = new ExtractedKey();
                extractedKey.SingleKeyCounts = new bool[4];
                int n = i;
                for (int j = 0; j < 4; j++)
                {
                    if ((n & 1) != 0)
                    {
                        extractedKey.KeyCount++;
                        extractedKey.SingleKeyCounts[j] = true;
                    }
                    else
                    {
                        extractedKey.SingleKeyCounts[j] = false;
                    }
                    n >>= 1;
                }
                extractedKeys.Add(extractedKey);
            }
        }

        public static FullKeyStats GetKeyStats(List<byte> ArrowKeyList)
        {
            KeyStats keyboard = new KeyStats();
            KeyStats controller = new KeyStats();
            FullKeyStats result = new FullKeyStats();
            result.TotalFrames = ArrowKeyList.Count;
            result.KeyboardKey = keyboard;
            result.ControllerKey = controller;

            //unused(17 bits) | controller key length(2 bits) | keyboard 3F key count(3bits) | 2F (3bits) | 1F (3bits) | key pressed(4bits)
            //进队列加数，出队列减数
            Queue<int> keyQueue = new Queue<int>();
            keyQueue.EnsureCapacity(61);
            for (int i = 0; i < 60; i++)
            {
                keyQueue.Enqueue(0);
            }
            int[] keyboardArrowLengthCounter = new int[4] { 0, 0, 0, 0 };
            int controllerArrowLengthCounter = 0;

            int[] keyboardArrow3LevelsCurrentSum = new int[3] { 0, 0, 0 };
            int[] controllerArrow3LevelsCurrentSum = new int[3] { 0, 0, 0 };
            int keyboardArrowCurrentSum = 0;
            int controllerArrowCurrentSum = 0;

            byte lastKey = 0;

            for (int i = 0; i < ArrowKeyList.Count; i++)
            {
                byte currentKey = ArrowKeyList[i];
                if ((currentKey | 3) != 0 || (currentKey | 12) != 0) result.HasConflictKeys = true;
                int currentData = currentKey;
                var tmpKey = extractedKeys[currentKey];

                for (int j = 0; j < tmpKey.SingleKeyCounts.Length; j++)
                {
                    if (tmpKey.SingleKeyCounts[j])
                    {
                        keyboardArrowLengthCounter[j]++;
                    }
                    else
                    {
                        int keyCount = keyboardArrowLengthCounter[j];
                        keyboard.TotalKeyLength += keyCount;
                        keyboard.TotalKeys++;
                        if (keyCount > 0 && keyCount <= 3)
                        {
                            int index = keyCount - 1;
                            currentData += 1 << (index * 3 + 4);
                            for (int k = keyCount; k >= 0; k--)
                            {
                                keyboard.KeyCounts[index][i - keyCount]++;
                            }
                            keyboardArrowLengthCounter[j] = 0;
                        }
                    }
                }

                if (!result.HasConflictKeys)
                {
                    if (lastKey == currentKey && currentKey != 0)
                    {
                        controllerArrowLengthCounter++;
                    }
                    else
                    {
                        int keyCount = controllerArrowLengthCounter;
                        controller.TotalKeyLength += keyCount;
                        controller.TotalKeys++;
                        if (keyCount > 0 && keyCount <= 3)
                        {
                            currentData |= keyCount << 13;
                            int index = keyCount - 1;
                            controllerArrow3LevelsCurrentSum[index]++;
                            for (int k = keyCount; k >= 0; k--)
                            {
                                controller.KeyCounts[index][i - keyCount]++;
                            }
                            controllerArrowLengthCounter = 0;
                        }
                        if (currentKey != 0)
                        {
                            controllerArrowCurrentSum++;
                        }
                    }
                }

                keyQueue.Enqueue(currentData);
                byte changedKey = (byte)(currentKey & (currentKey ^ lastKey));
                int tmpData = currentData >> 4;
                keyboardArrowCurrentSum += extractedKeys[changedKey].KeyCount;

                for (int j = 0; j < 3; j++)
                {
                    keyboardArrow3LevelsCurrentSum[j] += tmpData & 7;
                    tmpData >>= 3;
                }

                lastKey = currentKey;

                int outData = keyQueue.Dequeue();
                int firstData = keyQueue.Peek();
                byte outKey = (byte)(outData & 15);
                byte firstKey = (byte)(firstData & 15);
                if (!result.HasConflictKeys)
                {
                    int tmpControllerKeyCountLevel = (outData >> 13) & 3;
                    if (tmpControllerKeyCountLevel != 0)
                    {
                        controllerArrow3LevelsCurrentSum[tmpControllerKeyCountLevel - 1]--;
                    }
                    if (outKey != firstKey && outKey != 0)
                    {
                        controllerArrowCurrentSum--;
                    }
                }
                changedKey = (byte)(outKey & (outKey ^ firstKey));
                tmpData = outData >> 4;

                keyboardArrowCurrentSum -= extractedKeys[changedKey].KeyCount;

                for (int j = 0; j < 3; j++)
                {
                    keyboardArrow3LevelsCurrentSum[j] -= tmpData & 7;
                    tmpData >>= 3;
                }

                keyboard.KeyPressCount[i] = keyboardArrowCurrentSum;
                controller.KeyPressCount[i] = controllerArrowCurrentSum;
                for (int j = 0; j < 3; j++)
                {
                    keyboard.KeyCounts[j][i] = keyboardArrow3LevelsCurrentSum[j];
                    controller.KeyCounts[j][i] = controllerArrow3LevelsCurrentSum[j];
                }
            }

            keyboard.AverageKeyLength = ((double)keyboard.TotalKeyLength) / keyboard.TotalKeys;
            controller.AverageKeyLength = ((double)controller.TotalKeyLength) / controller.TotalKeys;

            return result;
        }

        private class ExtractedKey
        {
            public int KeyCount { get; set; }
            public bool[] SingleKeyCounts { get; set; }
        }
    }
}
