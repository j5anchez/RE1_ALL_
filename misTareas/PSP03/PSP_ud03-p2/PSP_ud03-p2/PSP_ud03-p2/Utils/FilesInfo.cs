using System;

namespace Utils
{
    public class FilesInfo
    {
        public string FileName { get; set; }
        public long Size { get; set; }
        public DateTime DateCreated { get; set; }
        public string Extension { get; set; }
        public string AbsolutePath { get; set; }
    }
}
