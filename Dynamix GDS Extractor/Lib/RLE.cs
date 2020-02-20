using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class RLE
    {
        public static byte[] Decompress(uint sz, byte[] encodeData)
        {
            List<byte> decodeData = new List<byte>();

            BinaryReader bin = new BinaryReader(new MemoryStream(encodeData));

            uint left = sz;

            byte val;
            uint lenR = 0, lenW = 0;

            using (bin)
            {
                while (left > 0 && bin.BaseStream.Position < encodeData.Length)
                {
                    lenR = bin.ReadByte();

                    if (lenR == 0x80)
                    {
                        lenW = 0;
                    }
                    else if (lenR <= 0x7f)
                    {
                        lenW = Math.Min(lenR, left);

                        for (int i = 0; i < lenW; i++)
                        {
                            decodeData.Add(bin.ReadByte());
                        }
                        for (; lenR > lenW; lenR--)
                        {
                            bin.ReadByte();
                        }
                    }
                    else
                    {
                        lenW = Math.Min(lenR & 0x7f, left);
                        val = bin.ReadByte();
                        decodeData.AddRange(Enumerable.Repeat(val, (int)lenW));
                    }

                    left -= lenW;
                }
            }

            return decodeData.ToArray();
        }
    }
}
