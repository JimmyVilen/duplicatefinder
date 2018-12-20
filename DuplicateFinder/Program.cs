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
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine(df.ToString());
            Console.WriteLine("\n\nPress any key to exit");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
