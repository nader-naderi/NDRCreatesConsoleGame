using System.Diagnostics;

namespace NDRCreatesConsoleGame.Engine
{
    public class Engine
    {
        /// <summary>
        /// The current game that is running in the game engine.
        /// </summary>
        private Game currentGame;

        /// <summary>
        /// Will help us to create delta time.
        /// </summary>
        private Stopwatch stopwatch;
        /// <summary>
        /// our delta time in seconds.
        /// </summary>
        private float deltaTimeInSeconds;

        /// <summary>
        /// Creating new instance of engine and assigning the desired game. 
        /// </summary>
        /// <param name="activeGame"> Desired Game </param>
        public Engine(Game activeGame)
        {
            InitailizeWatch();
            currentGame = activeGame;
        }

        private void InitailizeWatch()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void Run()
        {
            while (currentGame.IsGameRunning)
            {
                Draw();
                Update();
                ClearScreen();
            }
        }

        /// <summary>
        /// Update the engine.
        /// </summary>
        private void Update()
        {
            UpdateDeltaTime();
            currentGame.Update(deltaTimeInSeconds);
        }

        /// <summary>
        /// Update delta time.
        /// </summary>
        private void UpdateDeltaTime()
        {
            // find the gap between the previous frame.
            TimeSpan deltaTime = stopwatch.Elapsed;

            // restart the watch
            stopwatch.Restart();

            // calculate the previous time in second and assign it to deltatime.
            deltaTimeInSeconds = (float)deltaTime.TotalSeconds;
        }

        /// <summary>
        /// Clear the screen for redrawing.
        /// </summary>
        private static void ClearScreen()
        {
            // Delay the execution of program for 10 miliseconds.
            Thread.Sleep(10);

            // Clear the entire screen.
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Draw all of the objects in the game on screen.
        /// </summary>
        private void Draw()
        {
            currentGame.InitializeGridmap();
            currentGame.Render();
        }
    }
}
