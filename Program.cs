internal class Program
{
    private static void Main(string[] args)
    {
        using var game = new Space_Invaders.Game1();
        game.Run();
    }
}