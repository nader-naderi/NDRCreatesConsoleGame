namespace NDRCreatesConsoleGame.Engine
{
    public class Vector
    {
        public static Vector Zero { get; } = new Vector(0, 0);
        public static Vector One { get; } = new Vector(1, 1);
        public static Vector Up { get; } = new Vector(0, -1);
        public static Vector Down { get; } = new Vector(0, 1);
        public static Vector Left { get; } = new Vector(1, 0);
        public static Vector Right { get; } = new Vector(-1, 0);

        /// <summary>
        /// x coord
        /// </summary>
        private int x;
        /// <summary>
        /// y coord
        /// </summary>
        private int y;

        /// <summary>
        /// Initialize coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}