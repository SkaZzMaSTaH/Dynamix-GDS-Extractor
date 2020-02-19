using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lib
{
    public static class Implode
    {
        public static byte[] SaveChunks(List<FileFormat.Chunk.Common> Chunks)
        {
            List<byte> binData = new List<byte>();

            foreach (FileFormat.Chunk.Common Chunk in Chunks)
            {
                binData.AddRange(Encoding.Default.GetBytes(Chunk.ID));

                if (Chunk.IsContainer)
                {
                    binData.AddRange(BitConverter.GetBytes(Chunk.Size + 0x80000000));
                    binData.AddRange(SaveChunks(Chunk.SubChunks));
                }
                else
                {
                    binData.AddRange(BitConverter.GetBytes(Chunk.Size));
                    binData.AddRange(Chunk.Data);
                }
            }

            return binData.ToArray();
        }

        public static void SaveResource(FileFormat.Resource.Archive Archive, string fileName)
        {
            BinaryWriter bin = new BinaryWriter(File.Open(fileName, FileMode.Create), Encoding.Default);
            List<byte> binData = new List<byte>();

            using (bin)
            {
                if (Archive.IsFlat)
                {
                    bin.Write(Archive.Data);
                }
                else
                {
                    bin.Write(SaveChunks(Archive.Chunks));
                }
            }

            bin.Close();
        }
    }
}
