using System;

namespace MazeInfinite
{
    internal readonly struct MazeId
    {
        private readonly int x;
        private readonly int y;
        private readonly int rank;

        public MazeId ParentId
        {
            get => new MazeId(
                Math.Sign(x) * (Math.Abs(x) + 1) / 3,
                Math.Sign(y) * (Math.Abs(y) + 1) / 3,
                rank + 1);
        }

        public MazeId(int x, int y, int rank)
        {
            this.x    = x;
            this.y    = y;
            this.rank = rank;
        }

        public (int, int) RelativePosition
        {
            get => (
                Math.Sign(x) * ((Math.Abs(x) + 1) % 3 - 1),
                Math.Sign(y) * ((Math.Abs(y) + 1) % 3 - 1)
            );
        }

        public bool IsInCenter
        {
            get => x == 0 && y == 0;
        }

        public static implicit operator int(MazeId i)
        {
            var a = i.x;
            var b = i.y;
            var A = a >= 0 ? 2 *  a : -2 *  a - 1;
            var B = b >= 0 ? 2 *  b : -2 *  b - 1;
            var C = (A >= B ? A * A + A + B : A + B * B) / 2;
            return (a < 0 && b < 0 || a >= 0 && b >= 0 ? C : -C - 1);
        }

    }
}