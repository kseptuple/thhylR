using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thhylR.Games;

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
    }
}
