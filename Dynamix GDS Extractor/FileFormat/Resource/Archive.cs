using System.Collections.Generic;
using System.IO;

namespace FileFormat.Resource
{
    public class Archive
    {
        private string _file = string.Empty;
        private byte[] _data = new byte[] { };
        private List<Chunk.Common> _chunks = new List<Chunk.Common>();

        public string FileName { get { return Path.GetFileName(_file); } }
        public string FileExtension { get { return Path.GetExtension(_file); } }

        public byte[] Data { get { return _data; } }
        public List<Chunk.Common> Chunks { get { return _chunks; } }

        public bool IsFlat { get { return (_data.Length != 0) ? true : false; } }

        public uint Size
        {
            get
            {
                uint sz = 0;

                if (IsFlat == true)
                {
                    sz = (uint)_data.Length;
                }
                else
                {
                    foreach (Chunk.Common chunk in _chunks)
                    {
                        sz += chunk.Size + 8;
                    }
                }

                return sz;
            }
        }

        public Archive(string file, byte[] data)
        {
            _file = file;
            _data = data;

            ProcessData(data);
        }

        public void DecodeData()
        {
            ProcessChunks(_chunks);
        }

        private void ProcessData(byte[] data)
        {
            if (_data.Length == 0)
            {
                _data = new byte[] { };

                return;
            }
            if (_data[3] == 0x3a == true)
            {
                _chunks = Lib.Explode.LoadChunks(data);
                _data = new byte[] { };
            }
        }
        private void ProcessChunks(List<Chunk.Common> chunks)
        {
            if (IsFlat == true) { return; }

            for (int i = 0; i < chunks.Count; i++)
            {
                if (chunks[i].IsContainer == true)
                {
                    ProcessChunks(chunks[i].SubChunks);
                }
                else
                {
                    if (Lib.Toolkit.IsCompressed(FileExtension, chunks[i].ID)) { chunks[i].DecompressData(); }
                }
            }
        }
    }
}
