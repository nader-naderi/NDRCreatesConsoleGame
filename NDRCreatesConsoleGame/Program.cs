namespace NDRCreatesConsoleGame
{
    internal partial class Program
    {
        static void Main()
        {
            // Creating new Instance of Engine and assign our rogue game to it
            new Engine(new Rogue()).Run();
        }
    }
}