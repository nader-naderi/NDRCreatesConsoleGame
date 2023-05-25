namespace NDRCreatesConsoleGame
{
    public class Vector
    {
        private int x;
        private int y;

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }

    public class GameObject
    {
        // Fields, 
        private string name;
        private Vector position;

        public GameObject(string name, int x, int y)
        {
            this.name = name;
            this.position = new Vector(x, y);
        }

        // Properties
        public string Name
        {
            get
            {
                return name;
            }
        }

        public int X { get { return position.X; } }
        public int Y { get { return position.Y; } }

        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void MoveGameObject(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }
    }
}