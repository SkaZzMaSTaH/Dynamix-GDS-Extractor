using System.Collections.Generic;
using System.IO;

namespace FileFormat.FAT
{
    public class VolumeGameArchive
    {
        private string _file = string.Empty;

        private List<Resource.Archive> _archives = new List<Resource.Archive>();

        public string FileName { get { return Path.GetFileName(_file); } }
        public string FileExtension { get { return Path.GetExtension(_file); } }

        public List<Resource.Archive> Archives { get { return _archives; } }

        public VolumeGameArchive(string file)
        {
            _file = file;
        }

        public void AddArchive(string file, byte[] data)
        {
            _archives.Add(new Resource.Archive(file, data));
        }
    }
}
