using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace thhylR.Common
{
    public class ReplayDecrypt
    {
        private static uint GetBits(byte[] data, ref uint pointer, ref byte filter, byte length)
        {
            unchecked
            {
                byte i;
                uint result = 0;
                byte current;
                current = data[pointer];
                for (i = 0; i < length; ++i)
                {
                    result <<= 1;
                    if ((current & filter) != 0)
                        result |= 0x1;
                    filter >>= 1;
                    if (filter == 0)
                    {
                        pointer++;
                        if (pointer < data.Length)
                            current = data[pointer];
                        filter = 0x80;
                    }
                }
                return result;
            }
        }

        public static byte[] Decompress(byte[] originalData, int decompressedLength, int originalLength)
        {
            byte[] decode = new byte[decompressedLength];
            unchecked
            {
                uint pointer = 0, dest = 0, index, bits, i;
                byte filter = 0x80;
                byte[] dict = new byte[0x2000];
                //memset(dict, 0, 0x2010);
                while (pointer < originalLength)
                {
                    bits = GetBits(originalData, ref pointer, ref filter, 1);
                    if (pointer >= originalLength)
                        return decode;
                    if (bits != 0)
                    {
                        bits = GetBits(originalData, ref pointer, ref filter, 8);
                        if (pointer >= originalLength)
                            return decode;
                        decode[dest] = (byte)bits;
                        dict[dest & 0x1fff] = (byte)bits;
                        dest++;
                    }
                    else
                    {
                        bits = GetBits(originalData, ref pointer, ref filter, 13);
                        if (pointer >= originalLength)
                            return decode;
                        index = bits - 1;
                        bits = GetBits(originalData, ref pointer, ref filter, 4);
                        if (pointer >= originalLength)
                            return decode;
                        bits += 3;
                        for (i = 0; i < bits; ++i)
                        {
                            dict[dest & 0x1fff] = dict[index + i & 0x1fff];
                            decode[dest] = dict[index + i & 0x1fff];
                            dest++;
                        }
                    }
                }
                return decode;
            }
        }

        public static void DecodeV1(byte[] data, int start, int end, byte key, byte add)
        {
            for (int i = start; i < end; ++i)
            {
                data[i] -= key;
                key += add;
            }
        }

        public static void DecodeV2(byte[] data, int length, int blockSize, byte key, byte add)
        {
            unchecked
            {
                byte[] tbuf = data[0..length];
                //buffer.CopyTo(tbuf, 0);
                //memcpy(tbuf, buffer, length);
                int i, p = 0, tp1, tp2, hf, left = length;
                if (left % blockSize < blockSize / 4)
                    left -= left % blockSize;
                left -= length & 1;
                while (left != 0)
                {
                    if (left < blockSize)
                        blockSize = left;
                    tp1 = p + blockSize - 1;
                    tp2 = p + blockSize - 2;
                    hf = (blockSize + (blockSize & 0x1)) / 2;
                    for (i = 0; i < hf; ++i, ++p)
                    {
                        data[tp1] = (byte)(tbuf[p] ^ key);
                        key += add;
                        tp1 -= 2;
                    }
                    hf = blockSize / 2;
                    for (i = 0; i < hf; ++i, ++p)
                    {
                        data[tp2] = (byte)(tbuf[p] ^ key);
                        key += add;
                        tp2 -= 2;
                    }
                    left -= blockSize;
                }
                //delete[] tbuf;
            }
        }
    }
}
