using System;

using NDRCreatesConsoleGame.Engine;

namespace NDRCreatesConsoleGame.Games
{
    public class Rogue : Game
    {
        /// <summary>
        /// ai will decide to change it's direction per second.
        /// </summary>
        float changeDirectionRate = 1;
        /// <summary>
        /// timer for making decision happen.
        /// </summary>
        float directionTimer = 0;
        /// <summary>
        /// Storing the current scores.
        /// </summary>
        int scoreNumber = 0;

        /// <summary>
        /// player symbol.
        /// </summary>
        char playerChar = '$';
        /// <summary>
        /// enemy symbol
        /// </summary>
        char enemyChar = '@';
        /// <summary>
        /// coin symbol
        /// </summary>
        char coinChar = '*';

        /// <summary>
        /// coin object.
        /// </summary>
        GameObject coin = new GameObject("coin", 8, 6);
        /// <summary>
        /// player object.
        /// </summary>
        GameObject player = new GameObject("player", 5, 5);
        /// <summary>
        /// enemy object.
        /// </summary>
        GameObject enemy = new GameObject("enemy", 6, 7);

        public override void Update(float deltaTime)
        {
            UpdateEnemyBehvaior(deltaTime);
            UpdatePlayer();

            // handle game over on player collides with enemy.
            if (IsCollided(player.X, player.Y, enemy.X, enemy.Y))
                HandleGameOver();

            // handle coin collection on player collides with coin.
            if (IsCollided(player.X, player.Y, coin.X, coin.Y))
            {
                // increase number of coins.
                scoreNumber++;
                // changes coin's position ranomly.
                coin.SetPosition(random.Next(1, width - 1), random.Next(1, height - 1));
            }
        }

        /// <summary>
        /// Update player behaviour by input.
        /// </summary>
        private void UpdatePlayer()
        {
            // only proceed the procedure on a key pressed on keyboard.
            if (!Console.KeyAvailable)
                return;

            // store the information of pressed key.
            ConsoleKeyInfo input = Console.ReadKey(true);

            HandlePlayerMovement(input);
        }

        /// <summary>
        /// Move Player by input.
        /// </summary>
        /// <param name="input"></param>
        private void HandlePlayerMovement(ConsoleKeyInfo input)
        {
            if (input.KeyChar == 'w' && CanMove(player.X - 1, player.Y))
                player.MoveGameObject(-1, 0);
            else if (input.KeyChar == 's' && CanMove(player.X + 1, player.Y))
                player.MoveGameObject(+1, 0);
            else if (input.KeyChar == 'a' && CanMove(player.X, player.Y - 1))
                player.MoveGameObject(0, -1);
            else if (input.KeyChar == 'd' && CanMove(player.X, player.Y + 1))
                player.MoveGameObject(0, +1);
        }


        /// <summary>
        /// Updat enemy AI Behaviour
        /// </summary>
        /// <param name="deltaTime"></param>
        private void UpdateEnemyBehvaior(float deltaTime)
        {
            // count the timer
            directionTimer += deltaTime;

            // if timer is over make a decision.
            if (directionTimer <= changeDirectionRate)
                return;

            Vector direction = Vector.Zero;

            // loop through till the x and y direction not 0
            while (direction == Vector.Zero)
            {
                // Choose direction randomly
                direction = new Vector(random.Next(-1, 2), random.Next(-1, 2));

                // create new move vector based on dir
                Vector newEnemyPosition = new Vector(enemy.X + direction.X, enemy.Y + direction.Y);

                // if we could move, dont proceed.
                if (CanMove(newEnemyPosition.X, newEnemyPosition.Y))
                    continue;

                // we could not move, so reset the direction for restarting the iteration, till we have a walkable tile.
                direction = Vector.Zero;
            }

            // move the enemy by direction
            enemy.MoveGameObject(direction);

            // reset the timer for restarting the decision counter.
            directionTimer = 0;
        }

        public override void Render()
        {
            // create before rendering the world, so will be on top of the world
            RenderUIOnTop();
            base.Render();
            // create afterrendering the world, so will be on bottom of the world
            RenderUIOnBottom();
        }

        private void RenderUIOnBottom()
        {
            Console.WriteLine("Score : " + scoreNumber);
        }

        private void RenderUIOnTop()
        {

        }

        public override void InitializeGridmap()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    // allocate wall char to borders of the world, so we have walls on border.
                    if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                        grid[i, j] = wallChar;
                    else
                        // make the rest of cells empty.
                        grid[i, j] = ' ';
                }
            }

            // allocate game objects char on their coordinate in gridmap, so they will be drawen.
            grid[player.X, player.Y] = playerChar;
            grid[coin.X, coin.Y] = coinChar;
            grid[enemy.X, enemy.Y] = enemyChar;
        }
    }
}
