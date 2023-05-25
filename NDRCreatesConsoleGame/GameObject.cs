namespace NDRCreatesConsoleGame
{
    public class GameObject
    {
        // Fields, 
        /// <summary>
        /// gameObject's name
        /// </summary>
        private string name;
        /// <summary>
        /// gameObject's position
        /// </summary>
        private Vector position;

        /// <summary>
        /// Initialize Game Object
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="x">x coord</param>
        /// <param name="y">y coord</param>
        public GameObject(string name, int x, int y)
        {
            this.name = name;
            // creating the vector and assigning the x and y coordinates
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

        /// <summary>
        /// set positon based on the given argument.
        /// </summary>
        /// <param name="x">new x</param>
        /// <param name="y">new y</param>
        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        /// <summary>
        /// increament the current coord with this vecotr, used for smooth moving around.
        /// </summary>
        /// <param name="x">x multiplier </param>
        /// <param name="y">y multiplier </param>
        public void MoveGameObject(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }

        public void MoveGameObject(Vector newPos)
        {
            position.X += newPos.X;
            position.Y += newPos.Y;
        }
    }
}