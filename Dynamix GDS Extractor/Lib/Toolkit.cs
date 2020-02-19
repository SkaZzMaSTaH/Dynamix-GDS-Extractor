using System;
using System.Collections.Generic;

namespace Lib
{
    public static class Toolkit
    {
        public static string ClearChar(char[] characters)
        {
            const char NULL = (char)0x00;

            string charsCleaned = string.Empty;

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == NULL) { break; }

                charsCleaned += characters[i];
            }

            return charsCleaned;
        }

        public static int CreateHashName(char[] name, int hashRoot)
        {
            byte[] salt = BitConverter.GetBytes(hashRoot);
            int i = 0, c = 0;
            short isum = 0, ixor = 0;

            for (i = 0; i < name.Length; i++)
            {
                c = Char.ToUpper(name[i]);
                isum += (short)c;
                ixor ^= (short)c;
            }

            isum *= ixor;
            
            c = 0;

            for (ixor = 0; ixor < 4; ixor++)
            {
                c <<= 8;

                if (i > salt[ixor])
                {
                    c |= Char.ToUpper(name[salt[ixor]]);
                }
            }

            c += isum;

            return c;
        }

        public static bool IsArchiveCompressed(FileFormat.Resource.Archive Archive)
        {
            if (Archive.IsFlat == true) { return false; }

            return IsSomeChunkCompressed(Archive.Chunks, Archive.FileExtension);
        }

        public static bool IsSomeChunkCompressed(List<FileFormat.Chunk.Common> Chunks, string extension)
        {
            bool isCompressed = false;

            foreach (FileFormat.Chunk.Common Chunk in Chunks)
            {
                if (Chunk.IsContainer == true)
                {
                    isCompressed = IsSomeChunkCompressed(Chunk.SubChunks, extension);
                }
                else
                {
                    if (IsCompressed(extension, Chunk.ID))
                    {
                        isCompressed = true;
                        break;
                    }
                }
            }

            return isCompressed;
        }

        public static bool IsCompressed(string extension, char[] id)
        {
            bool isCompressed = false;

            switch (extension)
            {
                case ".ADS":
                case ".ADL":
                case ".ADH":
                    if (new string(id) == "SCR:") { isCompressed = true; }
                    break;
                case ".BMP":
                    if (new string(id) == "BIN:") { isCompressed = true; }
                    if (new string(id) == "VGA:") { isCompressed = true; }
                    break;
                case ".GDS":
                    if (new string(id) == "SDS:") { isCompressed = true; }
                    break;
                case ".SCR":
                    if (new string(id) == "BIN:") { isCompressed = true; }
                    if (new string(id) == "VGA:") { isCompressed = true; }
                    if (new string(id) == "MA8:") { isCompressed = true; }
                    break;
                case ".SDS":
                    if (new string(id) == "SDS:") { isCompressed = true; }
                    break;
                case ".SNG":
                    if (new string(id) == "SNG:") { isCompressed = true; }
                    break;
                case ".TTM":
                    if (new string(id) == "TT3:") { isCompressed = true; }
                    break;
                case ".TDS":
                    if (new string(id) == "THD:") { isCompressed = true; }
                    break;
                default:
                    break;
            }

            switch (extension)
            {
                case ".DDS":
                    if (new string(id) == "DDS:") { isCompressed = true; }
                    break;
                case ".OVL":
                    if (new string(id) == "001:") { isCompressed = true; }
                    if (new string(id) == "003:") { isCompressed = true; }
                    if (new string(id) == "004:") { isCompressed = true; }
                    if (new string(id) == "101:") { isCompressed = true; }
                    if (new string(id) == "ADL:") { isCompressed = true; }
                    if (new string(id) == "ADS:") { isCompressed = true; }
                    if (new string(id) == "APA:") { isCompressed = true; }
                    if (new string(id) == "ASB:") { isCompressed = true; }
                    if (new string(id) == "GMD:") { isCompressed = true; }
                    if (new string(id) == "M32:") { isCompressed = true; }
                    if (new string(id) == "NLD:") { isCompressed = true; }
                    if (new string(id) == "PRO:") { isCompressed = true; }
                    if (new string(id) == "PS1:") { isCompressed = true; }
                    if (new string(id) == "SBL:") { isCompressed = true; }
                    if (new string(id) == "SBP:") { isCompressed = true; }
                    if (new string(id) == "STD:") { isCompressed = true; }
                    if (new string(id) == "TAN:") { isCompressed = true; }
                    if (new string(id) == "T3V:") { isCompressed = true; }
                    if (new string(id) == "VGA:") { isCompressed = true; }
                    break;
                case ".TDS":
                    if (new string(id) == "TDS:") { isCompressed = true; }
                    break;
                default:
                    break;
            }

            return isCompressed;
        }
    }
}
