using System.Diagnostics;

using static NDRCreatesConsoleGame.Program;

namespace NDRCreatesConsoleGame
{
    public class Engine
    {
        private Game currentGame;

        private Stopwatch stopwatch;
        private float deltaTimeInSeconds;

        public Engine(Game activeGame)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            currentGame = activeGame;
        }

        public void Run()
        {
            while (currentGame.IsGameRunning)
            {
                UpdateDeltaTime();
                Draw();
                currentGame.Update(deltaTimeInSeconds);
                ClearScreen();
            }
        }

        private void UpdateDeltaTime()
        {
            TimeSpan deltaTime = stopwatch.Elapsed;
            stopwatch.Restart();

            deltaTimeInSeconds = (float)deltaTime.TotalSeconds;
        }

        private static void ClearScreen()
        {
            Thread.Sleep(10);
            Console.SetCursorPosition(0, 0);
        }

        private void Draw()
        {
            currentGame.InitializeGridmap();
            currentGame.Render();
        }
    }
}
