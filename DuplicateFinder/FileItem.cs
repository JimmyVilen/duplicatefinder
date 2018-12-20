using System;
using System.IO;
using System.Security.Cryptography;

namespace ImageDupliFinder
{
    public class FileItem
    {
        public string Filename { get; set; }
        public string AbsolutePath { get; set; }
        public string Checksum { get; set; }

        public FileItem(string file)
        {
            FileInfo f = new FileInfo(file);
            this.Filename = Path.GetFileName(f.FullName);
            this.AbsolutePath = file;

            using (var stream = new BufferedStream(File.OpenRead(file), Convert.ToInt32(f.Length)))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                this.Checksum = BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
            }

            
        }
    }
}