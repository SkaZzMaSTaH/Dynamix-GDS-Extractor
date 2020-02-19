using System.Collections.Generic;
using System.IO;

namespace Lib
{
    public static class Explode
    {
        public static FileFormat.FAT.VolumeGameIndex LoadFAT(string file)
        {
            const int MAX_VOLUME_LEN = 13;

            FileFormat.FAT.VolumeGameIndex VGIndex = null;

            BinaryReader bin = new BinaryReader(new MemoryStream(File.ReadAllBytes(file)));

            uint hashRoot;
            ushort countVolume, countIndexes;
            string nameVolume = string.Empty;

            using (bin)
            {
                hashRoot = bin.ReadUInt32();
                countVolume = bin.ReadUInt16();

                VGIndex = new FileFormat.FAT.VolumeGameIndex(
                    file,
                    hashRoot);

                for (int i = 0; i < countVolume; i++)
                {
                    nameVolume = Lib.Toolkit.ClearChar(bin.ReadChars(MAX_VOLUME_LEN));
                    countIndexes = bin.ReadUInt16();

                    VGIndex.AddVolumeIndex(nameVolume);

                    for (int j = 0; j < countIndexes; j++)
                    {
                        VGIndex.VolumeIndexes[i].AddIndex(
                            bin.ReadInt32(),
                            bin.ReadUInt32());
                    }
                }
            }

            bin.Close();
            return VGIndex;
        }

        public static FileFormat.FAT.VolumeGameArchive LoadVolume(FileFormat.FAT.VolumeGameIndex VolumeGameIndex, int index)
        {
            const int MAX_FILENAME_LEN = 13;

            FileFormat.FAT.VGAIndex VolumeIndex = VolumeGameIndex.VolumeIndexes[index];
            FileFormat.FAT.VolumeGameArchive VGArchive = new FileFormat.FAT.VolumeGameArchive(VolumeIndex.FileName);

            string pathVolume = VolumeGameIndex.FilePath + @"\" + VolumeIndex.FileName;

            BinaryReader bin = new BinaryReader(new MemoryStream(File.ReadAllBytes(pathVolume)));

            string fileName = string.Empty;
            uint fileSize = 0x00;
            byte[] fileData = new byte[] { };

            using (bin)
            {
                for (int i = 0; i < VolumeIndex.Count; i++)
                {
                    bin.BaseStream.Position = VolumeIndex.Offsets[i];

                    fileName = Toolkit.ClearChar(bin.ReadChars(MAX_FILENAME_LEN));
                    fileSize = bin.ReadUInt32();
                    fileSize = (fileSize == 0xffffffff) ? 0 : fileSize;     // #FIX: Willy Beamish
                    fileData = bin.ReadBytes((int)fileSize);

                    VGArchive.AddArchive(fileName, fileData);
                }
            }

            return VGArchive;
        }

        public static List<FileFormat.Chunk.Common> LoadChunks(byte[] data)
        {
            const byte MAX_ID_LEN = 4;

            List<FileFormat.Chunk.Common> chunks = new List<FileFormat.Chunk.Common>();
            BinaryReader reader = new BinaryReader(new MemoryStream(data));

            char[] id = new char[MAX_ID_LEN];
            uint size = 0;
            byte[] content = new byte[] { };
            bool isContainer = false;

            using (reader)
            {
                while (reader.BaseStream.Position < data.Length)
                {
                    id = reader.ReadChars(MAX_ID_LEN);

                    // FIX: Sometimes garbage at end
                    if (id.Length < MAX_ID_LEN) { break; }

                    size = reader.ReadUInt32();

                    if ((size & 0x80000000) == 0x80000000)
                    {
                        size &= ~0x80000000;
                        isContainer = true;
                    }

                    content = reader.ReadBytes((int)size);

                    chunks.Add(new FileFormat.Chunk.Common(id, isContainer, content));
                }
            }

            return chunks;
        }
    }
}
