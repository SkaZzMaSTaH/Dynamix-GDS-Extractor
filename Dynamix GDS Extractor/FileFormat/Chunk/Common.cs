using System;
using System.Collections.Generic;

namespace FileFormat.Chunk
{
    public class Common
    {
        protected char[] _id = new char[4];
        protected byte[] _content = new byte[] { };
        protected List<Common> _subChunks = new List<Common>();
        protected bool _isContainer = false;

        public char[] ID { get { return _id; } }
        public byte[] Data { get { return _content; } }
        public bool IsContainer { get { return _isContainer; } }
        public List<Common> SubChunks { get { return _subChunks; } }

        public uint Size
        {
            get
            {
                uint sizeChunk = 0;

                if (_isContainer)
                {
                    foreach (Common chunk in _subChunks)
                    {
                        sizeChunk += chunk.Size + 8;
                    }
                }
                else
                {
                    sizeChunk = (uint)(_content.Length);
                }

                return sizeChunk;
            }
        }

        public Common(char[] id, bool isContainer, byte[] data)
        {
            _id = id;
            _isContainer = isContainer;

            ProcessData(data);
        }
        public Common(Common chunk)
        {
            _id = chunk._id;
            _content = chunk._content;
            _subChunks = chunk._subChunks;
            _isContainer = chunk._isContainer;
        }

        protected void ProcessData(byte[] data)
        {
            if (_isContainer)
            {
                _subChunks = Lib.Explode.LoadChunks(data);
            }
            else
            {
                _content = data;
            }
        }

        public void DecompressData()
        {
            const int START_ENCODE = 5;

            byte[] resultData = new byte[] { };

            byte[] encodeData = new byte[] { };
            byte[] decodeData = new byte[] { };

            byte typeCompression = _content[0];
            uint szEncode = 0x00;
            uint szDecode = 0x00;

            if (typeCompression == 0x00 || typeCompression == 0x01) { return; }     // 0x01 = Willy Beamish
            if (typeCompression == 0x02)
            {
                szEncode = (uint)(_content.Length - START_ENCODE);
                szDecode = BitConverter.ToUInt32(new byte[4] { _content[1], _content[2], _content[3], _content[4] }, 0);

                if (szDecode == 0) { return; }

                encodeData = new byte[szEncode];
                decodeData = new byte[szDecode];
                resultData = new byte[szDecode + START_ENCODE];

                Array.Copy(_content, START_ENCODE, encodeData, 0, szEncode);

                decodeData = Lib.Unpack.DecompressLZW(szDecode, encodeData);

                resultData[0] = 0x00;       // Set type compression = 0;
                Array.Copy(_content, 1, resultData, 1, 4);
                Array.Copy(decodeData, 0, resultData, START_ENCODE, decodeData.Length);
            }

            _content = resultData;
        }
    }
}
