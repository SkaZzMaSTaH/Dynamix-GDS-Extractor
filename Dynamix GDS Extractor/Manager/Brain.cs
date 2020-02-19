using System.Collections.Generic;

namespace Manager
{
    public class Brain
    {
        private FileFormat.FAT.VolumeGameIndex _vgIndex = null;
        private List<FileFormat.FAT.VolumeGameArchive> _vgArchives = new List<FileFormat.FAT.VolumeGameArchive>();

        public FileFormat.FAT.VolumeGameIndex VGIndex { get { return _vgIndex; } }
        public List<FileFormat.FAT.VolumeGameArchive> VGArchives { get { return _vgArchives; } }

        
        public FileFormat.FAT.VolumeGameArchive VolumeSelected { get; set; }
        public FileFormat.Resource.Archive ArchiveSelected { get; set; }

        public Brain(FileFormat.FAT.VolumeGameIndex VGIndex)
        {
            _vgIndex = VGIndex;
        }

        public void AddArchive(FileFormat.FAT.VolumeGameArchive VGArchive)
        {
            _vgArchives.Add(VGArchive);
        }
    }
}
