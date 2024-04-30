using System;
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
            Func<byte[], int, int> getKeyData = null;
            var keyDataSettings = replay.GameData.StageSetting.KeyData;
            int[] arrowBits = new int[4];
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
                            break;
                        case "↓":
                            arrowBits[1] = i;
                            break;
                        case "←":
                            arrowBits[2] = i;
                            break;
                        case "→":
                            arrowBits[3] = i;
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

            replay.Stages[stageIndex].QuickPressCount = new List<int> { 0, 0, 0 };
            int[] arrowCount = new int[4] { 0, 0, 0, 0 };
            int[] lastArrowCount = new int[4] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
            int totalKeyLength = 0;
            int arrowKeyCount = 0;
            if (keyDataSettings.KeyDataVersion == 1)
            {
                int currentFrame = 1;
                string[] currentFrameKeyNames = null;
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
                        int continuousFrame = targetFrame - currentFrame;
                        for (int j = 0; j < keyIndices.Count; j++)
                        {
                            if ((keyDataInt & keyFlags[j]) != 0)
                            {
                                currentFrameKeyNames[keyIndices[j]] = keyDataSettings.KeyNames[keyIndices[j]];
                                for (int k = 0; k < 4; k++)
                                {
                                    if (keyIndices[j] == arrowBits[k])
                                    {
                                        arrowCount[k]+= continuousFrame;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (keyIndices[j] == arrowBits[k] && arrowCount[k] != 0)
                                    {

                                        lastArrowCount[k] = arrowCount[k];
                                        totalKeyLength += arrowCount[k];
                                        arrowKeyCount++;
                                        if (arrowCount[k] <= 3)
                                        {
                                            replay.Stages[stageIndex].QuickPressCount[arrowCount[k] - 1]++;
                                        }
                                        arrowCount[k] = 0;
                                    }
                                }
                            }
                        }

                        if (lastArrowCount[0] == lastArrowCount[2] || lastArrowCount[0] == lastArrowCount[3])
                        {
                            if (lastArrowCount[0] <= 3)
                                replay.Stages[stageIndex].QuickPressCount[lastArrowCount[0] - 1]--;
                        }
                        else if (lastArrowCount[1] == lastArrowCount[2] || lastArrowCount[1] == lastArrowCount[3])
                        {
                            if (lastArrowCount[1] <= 3)
                                replay.Stages[stageIndex].QuickPressCount[lastArrowCount[1] - 1]--;
                        }
                    }
                    currentFrame++;
                    replay.Stages[stageIndex].KeyList.Add(currentFrameKeyNames);

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
                    for (int j = 0; j < keyIndices.Count; j++)
                    {
                        if ((keyDataInt & keyFlags[j]) != 0)
                        {
                            currentFrameKeyNames[keyIndices[j]] = keyDataSettings.KeyNames[keyIndices[j]];
                            for (int k = 0; k < 4; k++)
                            {
                                if (keyIndices[j] == arrowBits[k])
                                {
                                    arrowCount[k]++;
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if (keyIndices[j] == arrowBits[k] && arrowCount[k] != 0)
                                {
                                    lastArrowCount[k] = arrowCount[k];
                                    totalKeyLength += arrowCount[k];
                                    arrowKeyCount++;
                                    if (arrowCount[k] <= 3)
                                    {
                                        replay.Stages[stageIndex].QuickPressCount[arrowCount[k] - 1]++;
                                    }
                                    arrowCount[k] = 0;
                                }
                            }
                        }
                    }

                    if (lastArrowCount[0] == lastArrowCount[2] || lastArrowCount[0] == lastArrowCount[3])
                    {
                        if (lastArrowCount[0] <= 3)
                            replay.Stages[stageIndex].QuickPressCount[lastArrowCount[0] - 1]--;
                    }
                    else if (lastArrowCount[1] == lastArrowCount[2] || lastArrowCount[1] == lastArrowCount[3])
                    {
                        if (lastArrowCount[1] <= 3)
                            replay.Stages[stageIndex].QuickPressCount[lastArrowCount[1] - 1]--;
                    }

                    replay.Stages[stageIndex].KeyList.Add(currentFrameKeyNames);
                }
            }

            if (arrowKeyCount > 0)
            {
                replay.Stages[stageIndex].AverageKeyLength = ((double)totalKeyLength) / arrowKeyCount;
            }
            else
            {
                replay.Stages[stageIndex].AverageKeyLength = 0d;
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
    }
}
