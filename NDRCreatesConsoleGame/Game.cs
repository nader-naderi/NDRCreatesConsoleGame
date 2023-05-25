using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDRCreatesConsoleGame
{
    public abstract class Game
    {
        protected Random random = new();

        protected const int width = 15;
        protected const int height = 30;
        protected char[,] grid = new char[width, height];
        protected char wallChar = '#';


        public bool IsGameRunning { get; private set; } = true;

        public abstract void Update(float deltaTime);

        protected bool CanMove(int x, int y)
        {
            bool canMove;

            if (x < 0
                || x >= width
                || y < 0
                || y >= height)
                canMove = false;

            canMove = grid[x, y] != wallChar;

            return canMove;
        }

        protected bool CanMove(Vector target) => CanMove(target.X, target.Y);

        protected void HandleGameOver()
        {
            IsGameRunning = false;

            Console.SetCursorPosition(0, 0);

            Console.WriteLine("Game Over");
        }

        protected bool IsCollided(int aX, int aY, int bX, int bY) => aX == bX && aY == bY;

        public virtual void Render()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                    Console.Write(grid[i, j]);

                Console.WriteLine();
            }
        }

        public abstract void InitializeGridmap();
    }
}
