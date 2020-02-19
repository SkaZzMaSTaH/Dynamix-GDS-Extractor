using System.Collections.Generic;
using System.IO;

namespace FileFormat.FAT
{
    public class VolumeGameIndex
    {
        private string _file = string.Empty;

        private int _hashRoot = 0x00;

        private List<VGAIndex> _volumeIndexes = new List<VGAIndex>();

        public string File { get { return _file; } }
        public string FileName { get { return Path.GetFileName(_file); } }
        public string FileExtension { get { return Path.GetExtension(_file); } }
        public string FilePath { get { return Path.GetDirectoryName(_file); } }

        public int HashRoot { get { return _hashRoot; } }

        public List<VGAIndex> VolumeIndexes { get { return _volumeIndexes; } }

        public ushort Count { get { return (ushort)_volumeIndexes.Count; } }

        public VolumeGameIndex(string file, uint hashRoot)
        {
            _file = file;
            _hashRoot = (int)hashRoot;
        }

        public void AddVolumeIndex(string filename)
        {
            _volumeIndexes.Add(new VGAIndex(filename));
        }
    }

    public class VGAIndex
    {
        private string _fileName = string.Empty;
        private List<int> _hashNames = new List<int>();
        private List<uint> _offsets = new List<uint>();

        public string FileName { get { return _fileName; } }
        public List<int> HashNames { get { return _hashNames; } }
        public List<uint> Offsets { get { return _offsets; } }
        
        public ushort Count { get { return (ushort)((_hashNames.Count + _offsets.Count) / 2); } }

        public VGAIndex(string filename)
        {
            _fileName = filename;
        }

        public void AddIndex(int hashName, uint offset)
        {
            _hashNames.Add(hashName);
            _offsets.Add(offset);
        }
    }
}
