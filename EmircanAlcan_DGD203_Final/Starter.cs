using System;

using DGD203;
internal class Starter
{
    private static void Main(string[] args)
    {
        Game gameInstance = new();
        gameInstance.StartGame(gameInstance);
    }
}