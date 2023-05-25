using System;

namespace NDRCreatesConsoleGame
{
    public class Rogue : Game
    {
        float changeDirectionRate = 1;
        float directionTimer = 0;
        int scoreNumber = 0;

        char playerChar = '$';
        char enemyChar = '@';
        char coinChar = '*';

        GameObject coin = new GameObject("coin", 8, 6);
        GameObject player = new GameObject("player", 5, 5);
        GameObject enemy = new GameObject("enemy", 6, 7);

        public override void Update(float deltaTime)
        {
            UpdateEnemyBehvaior(deltaTime);
            UpdatePlayer();

            if (IsCollided(player.X, player.Y, enemy.X, enemy.Y))
                HandleGameOver();

            if (IsCollided(player.X, player.Y, coin.X, coin.Y))
            {
                scoreNumber++;
                coin.SetPosition(random.Next(1, width - 1), random.Next(1, height - 1));
            }
        }

        private void UpdatePlayer()
        {
            if (!Console.KeyAvailable)
                return;

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.KeyChar == 'w' && CanMove(player.X - 1, player.Y))
                player.MoveGameObject(-1, 0);
            else if (input.KeyChar == 's' && CanMove(player.X + 1, player.Y))
                player.MoveGameObject(+1, 0);
            else if (input.KeyChar == 'a' && CanMove(player.X, player.Y - 1))
                player.MoveGameObject(0, -1);
            else if (input.KeyChar == 'd' && CanMove(player.X, player.Y + 1))
                player.MoveGameObject(0, +1);
        }

        private void UpdateEnemyBehvaior(float deltaTime)
        {
            directionTimer += deltaTime;

            if (directionTimer > changeDirectionRate)
            {
                int directionX = 0;
                int directionY = 0;

                while (directionX == 0 && directionY == 0)
                {
                    directionX = random.Next(-1, 2);
                    directionY = random.Next(-1, 2);

                    int newEnemyX = enemy.X + directionX;
                    int newEnemyY = enemy.Y + directionY;
                    if (!CanMove(newEnemyX, newEnemyY))
                    {
                        directionX = 0;
                        directionY = 0;
                    }
                }

                enemy.MoveGameObject(directionX, directionY);

                directionTimer = 0;
            }
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Score : " + scoreNumber);
        }

        public override void InitializeGridmap()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                        grid[i, j] = wallChar;
                    else
                        grid[i, j] = ' ';
                }
            }

            grid[player.X, player.Y] = playerChar;
            grid[coin.X, coin.Y] = coinChar;
            grid[enemy.X, enemy.Y] = enemyChar;
        }
    }
}
