using System.Reflection;

namespace thhylR.Common
{
    [Obfuscation(Exclude=false)]
    public static class ReplayDecrypt
    {

        public static byte[] Decompress(byte[] originalData, int decompressedLength, int originalLength)
        {
            byte[] decompressed = new byte[decompressedLength];
            unchecked
            {
                uint pos = 0;
                uint indexInDict = 0;
                uint bitsData;
                int decompressPos = 0;
                int bitPos = 7;
                int dictPosInData = 0;
                uint matchLength = 0;
                while ((originalLength - pos) * 8 + bitPos >= 16)
                {
                    bitsData = getByBits(1);
                    if (bitsData != 0)
                    {
                        bitsData = getByBits(8);
                        decompressed[decompressPos] = (byte)bitsData;
                        decompressPos++;
                    }
                    else
                    {
                        if ((originalLength - pos) * 8 + bitPos < 24)
                        {
                            return decompressed;
                        }
                        bitsData = getByBits(13);
                        indexInDict = bitsData - 1;
                        bitsData = getByBits(4);
                        matchLength = bitsData + 3;
                        dictPosInData = (int)(decompressPos - ((uint)(decompressPos - indexInDict) & 0x1fff));
                        for (uint i = 0; i < matchLength; ++i)
                        {
                            decompressed[decompressPos] = decompressed[dictPosInData + i];
                            decompressPos++;
                        }
                    }
                }
                return decompressed;


                uint getByBits(int length)
                {
                    unchecked
                    {
                        bitPos++;
                        int mask = 0;
                        uint result = 0;
                        while (length >= bitPos)
                        {
                            mask = (1 << bitPos) - 1;
                            result <<= bitPos;
                            result |= (uint)(originalData[pos] & mask);
                            length -= bitPos;
                            pos++;
                            bitPos = 8;
                        }

                        mask = (1 << length) - 1;
                        bitPos -= length;

                        result <<= length;
                        result |= (uint)((originalData[pos] >> bitPos) & mask);

                        bitPos--;
                        return result;
                    }
                }
            }
        }

        public static void DecodeV1(byte[] data, int start, int end, byte key, byte add)
        {
            for (int i = start; i < end; i++)
            {
                data[i] -= key;
                key += add;
            }
        }

        public static void DecodeV2(byte[] data, int length, int blockSize, byte key, byte add)
        {
            unchecked
            {
                byte[] encodedData = data[0..length];

                int decodeLengthLeft = length;
                if (decodeLengthLeft % blockSize < blockSize / 4)
                {
                    decodeLengthLeft -= decodeLengthLeft % blockSize;
                }

                decodeLengthLeft -= length & 1;
                int encodedPos = 0;
                int decodedPos = 0;
                int currentBlockStart = 0;

                while (decodeLengthLeft > 0)
                {
                    if (decodeLengthLeft < blockSize)
                    {
                        blockSize = decodeLengthLeft;
                    }
                    currentBlockStart = encodedPos;

                    decodedPos = currentBlockStart + blockSize - 1;
                    while (decodedPos >= currentBlockStart)
                    {
                        data[decodedPos] = (byte)(encodedData[encodedPos] ^ key);
                        key += add;
                        decodedPos -= 2;
                        encodedPos++;
                    }

                    decodedPos = currentBlockStart + blockSize - 2;
                    while (decodedPos >= currentBlockStart)
                    {
                        data[decodedPos] = (byte)(encodedData[encodedPos] ^ key);
                        key += add;
                        decodedPos -= 2;
                        encodedPos++;
                    }
                    decodeLengthLeft -= blockSize;
                }
            }
        }
    }
}
