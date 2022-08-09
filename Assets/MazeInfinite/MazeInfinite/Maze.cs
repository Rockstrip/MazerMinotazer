using System;

namespace MazeInfinite
{
    internal readonly struct Maze
    {
        private readonly Cell[,] cells;
        private readonly Cell    basisCell;

        private Maze(MazeId id, Cell basis = new Cell())
        {
            cells     = FiniteMaze.Generate(id);
            basisCell = basis;
            
            var rn = new Random(id);
            
            cells[rn.Next(0, 2), 2].Top    = basis.Top;
            cells[rn.Next(0, 2), 0].Bottom = basis.Bottom;
            cells[2, rn.Next(0, 2)].Right  = basis.Right;
            cells[0, rn.Next(0, 2)].Left   = basis.Left;
        }

        public static Cell Generate(int x, int y)
        {
            return GetMaze(new MazeId(x, y, 1)).basisCell;
        }

        private static Maze GetMaze(MazeId id)
        {
            var parent = id.IsInCenter 
                ? new Maze(id.ParentId)
                : GetMaze(id.ParentId);
            
            return parent.Submaze(id);
        }

        private Maze Submaze(MazeId subId)
        {
            var (rx, ry) = subId.RelativePosition;
            
            var basis = cells[rx + 1, ry + 1];
            var maze  = new Maze(subId, basis);
            return maze;
        }

    }
}