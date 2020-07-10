using System;
using static System.Console;

class MainClass
{

    public static void Main(string[] args)
    {
        GameController gameController = new GameController();
        gameController.MainMenuLoop();
    }
}