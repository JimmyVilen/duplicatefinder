using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ImageDupliFinder
{
    public class DuplicateFinder
    {
        private List<FileItem> _list = null;
        private IGrouping<string, FileItem>[] _duplicates = null;

        public DuplicateFinder()
        {
            this._list = new List<FileItem>();
        }

        public void FindFiles(string path, string file_extension)
        {
            Console.WriteLine($"Analyzing files in: {path}");
            var files = System.IO.Directory.EnumerateFiles(path, file_extension, System.IO.SearchOption.AllDirectories).ToArray();

            for(int i = 0;i<files.Length;i++)
            {
                _list.Add(new FileItem(files[i]));
                drawTextProgressBar(i, files.Length);
            }
            Console.WriteLine();
        }

        public IGrouping<string, FileItem>[] GetDuplicates()
        {
            Console.WriteLine($"Creating result with duplicates");
            _duplicates = _list.GroupBy(x => x.Checksum).Where(x => x.Count() > 1).ToArray();
            return _duplicates;
        }

        public override string ToString()
        {
            string output = "\n\n";
            for(int i = 0; i < _duplicates.Length; i++)
            {
                var df = _duplicates[i].ToArray();
                output += $"{df[0].Filename}\n";
                foreach (var f in df)
                {
                    output += $"---> {f.AbsolutePath}\n";
                }
                drawTextProgressBar(i, _duplicates.Length);
            }
            return output;
        }

        public List<FileItem> GetDuplicatesList()
        {
            Console.WriteLine($"Creating result with duplicates");

            List<FileItem> duplicate_files = new List<FileItem>();
            var q = _list.GroupBy(x => x.Checksum).Where(x => x.Count() > 1).ToArray();
            for (int i = 0; i < q.Count(); i++)
            {
                var dup_img = q[i].ToArray();
                foreach (var img in dup_img)
                {
                    duplicate_files.Add(img);
                }
                drawTextProgressBar(i, q.Length);
            }
            Console.WriteLine();
            return duplicate_files;
        }

        private static void drawTextProgressBar(int progress, int total)
        {
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
        }
    }
}
