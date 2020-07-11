using System;
using static System.Console;

class GameController
{
    GameRPS game;
    GamesRecord gamesRecord;

    public GameController()
    {
        gamesRecord = new GamesRecord();
    }

    public void DisplayRules(bool withWelcomeMessage = true)
    {
        if (withWelcomeMessage)
        {
            WriteLine("Welcome to a simple Rock-Paper-Scissors game!");
        }
        WriteLine("The rules are very simple - each player chooses Rock, Paper or Scissors choice by entering the choice's number\n[1] Rock\n[2] Paper\n[3] Scissors\nand confirm it by clicking Enter.\nAfter both player choose, the winner is determined. After each game the application will ask the players if they want to continue, and if the player repond with anything else than [y]es than the game finishes and presents the record of the last up to 10 games.\n\nHave fun!");
    }

    public void MainMenuLoop()
    {
        // Declare the variable used for input
        ConsoleKeyInfo inputKey;

        // Control the effect of input to call a proper function
        do
        {
            // Clear the console
            Clear();
            // Write the menu message
            WriteLine("Rock-Paper-Scissors Menu:\n[1] Player vs Player\n[2] Player vs AI\n[3] Show rules\n[4] Display last games' record\n[ESC] Exit");
            inputKey = ReadKey(true);
            if (inputKey.Key == ConsoleKey.D1)
            {
                game = new GameRPS();
                game.Play();
                gamesRecord += game.gamesRecord;
            }
            else if (inputKey.Key == ConsoleKey.D2)
            {
                game = new GameRPS(true);
                game.Play();
                gamesRecord += game.gamesRecord;
            }
            else if (inputKey.Key == ConsoleKey.D3)
            {
                DisplayRules(false); // false to not display the "Welcome.." part
            }
            else if (inputKey.Key == ConsoleKey.D4)
            {
                gamesRecord.DisplayGamesHistory();
            }
            else { continue; }
            WriteLine("(click any key to continue)");
            ReadKey(true);
        } while (inputKey.Key != ConsoleKey.Escape);
    }
}