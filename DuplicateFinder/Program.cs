using System;

namespace ImageDupliFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            DuplicateFinder df = new DuplicateFinder();
            df.FindFiles(args[0], args[1]);
            var duplictes = df.GetDuplicates();
            //System.Threading.Thread.Sleep(3000);
            //Console.WriteLine(df.ToString());

            var moved_files = df.MoveDuplicates(@"G:\Photos_moved", @"G:\Photos\Import");
            Console.WriteLine("\n\nPress any key to exit");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
