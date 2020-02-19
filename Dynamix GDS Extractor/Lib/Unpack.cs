using System.IO;

namespace Lib
{
    public static class Unpack
    {
        public static byte[] DecompressLZW(uint sz, byte[] data)
        {
            LZW LZW = new LZW();
            BinaryReader bin = new BinaryReader(new MemoryStream(data));

            return LZW.Decompress(sz, bin);
        }
    }
}
