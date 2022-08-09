namespace MazeInfinite
{
    public struct Cell
    {
        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;

        public static Cell AtPoint(int x, int y)
        {
            return Maze.Generate(x, y);
        }

        public override string ToString()
        {
            if (Right && Bottom)
                return "▛";
            else if (Bottom)
                return "▌";
            else if (Right)
                return "▀";
            else
                return "▘";
        }
    }
}