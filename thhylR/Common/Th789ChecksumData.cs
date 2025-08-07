using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace thhylR.Common
{
    [Obfuscation(Exclude = false)]
    public static class Th789ChecksumData
    {
        public static Dictionary<string, GameChecksum> GameChecksums =
            new() {
                { "Th07", new (0x84, 0x0009EE00, 0xAEC5445C, "0100b") } ,
                { "Th08", new (0xbc, 0x000CD400, 0xA26861B9, "0100d") },
                { "Th09", new (0x114, 0x000A7400, 0xABEE4C8F, "0150a") }
            };


        public static bool IsModdedVersion(string gameId, byte[] afterDecompressData)
        {
            if (GameChecksums.TryGetValue(gameId, out GameChecksum gameChecksum))
            {
                int offset = gameChecksum.ChecksumOffset;
                if (Encoding.ASCII.GetString(afterDecompressData[(offset + 8)..(offset + 13)]) != gameChecksum.GameVersion)
                {
                    return false;
                }
                if (BitConverter.ToInt32(afterDecompressData, offset) == gameChecksum.ExeSize && BitConverter.ToUInt32(afterDecompressData, offset + 4) == gameChecksum.ExeChecksum)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public record GameChecksum(int ChecksumOffset, int ExeSize, uint ExeChecksum, string GameVersion);
}
