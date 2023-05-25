using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDRCreatesConsoleGame
{
    /// <summary>
    /// Base class for any type of game that needs to be runned on engine.
    /// </summary>
    public abstract class Game
    {
        /// <summary>
        /// a new random for generating random numbers.
        /// </summary>
        protected Random random = new();

        /// <summary>
        /// width and height of our scene.
        /// </summary>
        protected const int width = 15;
        protected const int height = 30;
        /// <summary>
        /// Grid map the world will be generated on this 2D array as our game world.
        /// </summary>
        protected char[,] grid = new char[width, height];
        /// <summary>
        /// block for walls
        /// </summary>
        protected char wallChar = '#';

        /// <summary>
        /// a flag for representing the state of game.
        /// </summary>
        public bool IsGameRunning { get; private set; } = true;

        /// <summary>
        /// Update all of the game objects.
        /// </summary>
        /// <param name="deltaTime"> Populated by Engine </param>
        public abstract void Update(float deltaTime);

        /// <summary>
        /// Is the Object allows to move.
        /// </summary>
        /// <param name="x">x coordinate of the object </param>
        /// <param name="y">y coordinate of the object </param>
        /// <returns> can move or not? </returns>
        protected bool CanMove(int x, int y)
        {
            bool canMove;

            if (x < 0 // is on the left border
                || x >= width // is on the right border
                || y < 0 // is on the up border
                || y >= height) // is on the bottom
                canMove = false; // if yes, is not allow for moving to it.

            // is the x, y  coord, mapping a obstacle?
            canMove = grid[x, y] != wallChar;

            // TODO: Replace the wall char with Tag Gameobject (2D grid of Game Objects) or
            // Cell.cs a class for containing 2D grid derived from the game obejct.

            return canMove;
        }

        protected bool CanMove(Vector target) => CanMove(target.X, target.Y);

        protected void HandleGameOver()
        {
            // terminate the game.
            IsGameRunning = false;

            // clear 
            Console.SetCursorPosition(0, 0);

            // show game over.
            Console.WriteLine("Game Over");
        }

        /// <summary>
        /// Is object a collided with object b? 
        /// </summary>
        /// <param name="aX">object a's X</param>
        /// <param name="aY">object a's Y</param>
        /// <param name="bX">object b's X</param>
        /// <param name="bY">object b's Y</param>
        /// <returns> is collided or not? </returns>
        protected bool IsCollided(int aX, int aY, int bX, int bY) => aX == bX && aY == bY;

        /// <summary>
        /// Render the world based on the valus in our 2D array gridmap data structure.
        /// </summary>
        public virtual void Render()
        {
            // first dimension (width)
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                // second dimension (height)
                for (int j = 0; j < grid.GetLength(1); j++)
                    // print the current x = i, y = j object to screen.
                    Console.Write(grid[i, j]);

                // go to the next line.
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Initialize the base data strcuture of the map.
        /// </summary>
        public abstract void InitializeGridmap();
    }
}
