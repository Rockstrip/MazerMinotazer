using System;

namespace MazeInfinite
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var s = args.Length > 0 ? Int32.Parse(args[0]) : 4;
            
            Console.WriteLine();
            for (var y = s; y >= -s; y--)
            {
                for (var x = -s; x <= s; x++)
                {
                    Console.Write(Cell.AtPoint(x, y));
                }
                Console.WriteLine();
            }
        }
    }
}