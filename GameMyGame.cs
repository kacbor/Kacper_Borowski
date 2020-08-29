using Kacper_Borowski;
using System;
using System.Collections.Generic;

internal class GameMyGame : Game
{
    Random random;
    public GameMyGame(bool singleplayer = false)
    {
        GameName = "Moja Gra";
        GameRules = "Zasady gry...Rzut kością- gracz z największą liczbą wygrywa.";
        inputTable = new Dictionary<string, string>()
        {
            {"1", "Roll" }
        };
        while (true)
        {
            try
            {
                playerOne = new Player();
            }
            catch (Exception e)
            {
                continue;
            }
            break;
        }

        while (true)
        {
            try
            {
                if (singleplayer) playerTwo = new AIPlayer();
                else playerTwo = new Player();
            }
            catch (Exception e)
            {
                continue;
            }
            break;
        }


        gamesRecord = new GamesRecord();

        random = new Random();





    }
    
    
    public override void Play()
    {
        Console.WriteLine($"{playerOne.PlayerName}: Roll the die.");
        playerOne.GetInput(inputTable);
        int playerOneChoice = random.Next(7);
        Console.WriteLine($"{playerTwo.PlayerName}: Roll the die.");
        playerTwo.GetInput(inputTable);
        int playerTwoChoice = random.Next(7);

        string winner = DetermineWinner(playerOneChoice, playerTwoChoice);

        Console.WriteLine($"{playerOne.PlayerName} rolled {playerOneChoice}.");
        Console.WriteLine($"{playerTwo.PlayerName} rolled {playerTwoChoice}.");
        Console.WriteLine($"Winner: {winner}");

        gamesRecord.AddRecord(new RecordDice(playerOneChoice.ToString(), playerTwoChoice.ToString(), winner));

        

    }
    private string DetermineWinner(int playerOneChoice, int playerTwoChoice)
    {
        if (playerOneChoice > playerTwoChoice)
        {
            return playerOne.PlayerName + " won.";
        }
        else if (playerTwoChoice > playerOneChoice)
        {
            return playerTwo.PlayerName + " won.";
        }
        else
        {
            return "Draw";
        }
    }
}

internal class RecordDice : IRecord
{
    private string v1;
    private string v2;
    private string winner;

    public RecordDice(string v1, string v2, string winner)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.winner = winner;
    }
}