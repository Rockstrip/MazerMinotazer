using System;
using System.Collections.Generic;

namespace MazeInfinite
{
    internal static class FiniteMaze
    {
        private enum Dir { Left, Right, Up, Down }

        public static Cell[,] Generate(int hash)
        {
            var map     = new Cell[3, 3];
            var visited = new bool[3, 3];
            var rn      = new Random(hash);
            var x       = 0;
            var y       = 0;
            var path    = new Stack<(int, int)>();
            
            do
            {
                var freeDirs = new List<Dir>();

                if (x > 0 && !visited[x - 1, y])
                    freeDirs.Add(Dir.Left);
                if (x < 2 && !visited[x + 1, y])
                    freeDirs.Add(Dir.Right);
                if (y > 0 && !visited[x, y - 1])
                    freeDirs.Add(Dir.Down);
                if (y < 2 && !visited[x, y + 1])
                    freeDirs.Add(Dir.Up);

                visited[x, y] = true;

                if (freeDirs.Count == 0)
                {
                    (x, y) = path.Pop();
                }
                else
                {
                    var dir = freeDirs[rn.Next(freeDirs.Count)];

                    path.Push((x, y));

                    switch (dir)
                    {
                        case Dir.Left:
                            map[x, y].Left = true;
                            x--;
                            map[x, y].Right = true;
                            break;
                        case Dir.Right:
                            map[x, y].Right = true;
                            x++;
                            map[x, y].Left = true;
                            break;
                        case Dir.Up:
                            map[x, y].Top = true;
                            y++;
                            map[x, y].Bottom = true;
                            break;
                        case Dir.Down:
                            map[x, y].Bottom = true;
                            y--;
                            map[x, y].Top = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

            } while (x != 0 || y != 0);

            return map;
        }
    }
}