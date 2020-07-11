using Kacper_Borowski;
using System;
using static System.Console;

class GameController
{
    string[] gameType = { "RPS", "???" };
    int currentGameTypeIndex = 0;


    Game game;
    GamesRecord gamesRecord;

    public GameController()
    {
        gamesRecord = new GamesRecord();
    }

    public void DisplayRules(Game game, bool withWelcomeMessage = true)
    {
        if (withWelcomeMessage)
        {
            WriteLine("Welcome to a {0} game!", game.GameName);
        }
        WriteLine(game.GameRules);
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
            WriteLine("Game Menu - Current game [{0}]:\n[1] Player vs Player\n[2] Player vs AI\n[3] Show rules\n[4] Display last games' record\n[5] Change game\n[ESC] Exit", gameType[currentGameTypeIndex]);
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
                DisplayRules(game, false); // false to not display the "Welcome.." part
            }
            else if (inputKey.Key == ConsoleKey.D4)
            {
                gamesRecord.DisplayGamesHistory();
            }
            else if (inputKey.Key == ConsoleKey.D5)
            {
                currentGameTypeIndex = (currentGameTypeIndex + 1) % gameType.Length;
                continue;
            }
            else { continue; }
            WriteLine("(click any key to continue)");
            ReadKey(true);
        } while (inputKey.Key != ConsoleKey.Escape);
    }
}