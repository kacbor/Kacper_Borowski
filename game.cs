﻿using System;
using System.Collections.Generic;
using static System.Console;

class Game
{
    Player playerOne, playerTwo;
    Dictionary<string, string> inputTable = new Dictionary<string, string>()
    {
      {"1", "Rock"},
      {"2", "Paper"},
      {"3", "Scissors"}
    };
    public GamesRecord gamesRecord;

    public Game(bool singleplayer = false)
    {
        playerOne = new Player();
        if (singleplayer) playerTwo = new AIPlayer();
        else playerTwo = new Player();
        gamesRecord = new GamesRecord();
    }

    public string GetPlayerInput(Player player)
    {
        // Variable declaration
        string rawInput;
        string properInput;

        // Prompt for input
        WriteLine("{0}, Choose:\n[1] Rock\n[2] Paper\n[3] Scissors", player.playerName);

        // Get player input
        rawInput = ReadLine();

        // Verify input and reprompt if wrong
        while (rawInput != "1" && rawInput != "2" && rawInput != "3")
        {
            WriteLine("Wrong input. Please enter correct one.\nPlayer One, choose:\n[1] Rock\n[2] Paper\n[3] Scissors");
            rawInput = ReadLine();
        }

        // Translate the raw input into proper one
        if (rawInput == "1") { properInput = "Rock"; }
        else if (rawInput == "2") { properInput = "Paper"; }
        else { properInput = "Scissors"; }

        return properInput;
    }

    public string DetermineWinner(Player playerOne, Player playerTwo)
    {
        if (playerOne.lastInput == playerTwo.lastInput)
        {
            WriteLine("It's a draw!");
            return "Draw";
        }
        else if ((playerOne.lastInput == "Rock" && playerTwo.lastInput == "Scissors") ||
                (playerOne.lastInput == "Paper" && playerTwo.lastInput == "Rock") ||
                (playerOne.lastInput == "Scissors" && playerTwo.lastInput == "Paper"))
        {
            Console.WriteLine("{0} won!", playerOne.playerName);
            return String.Format("{0} won!", playerOne.playerName);
        }
        else
        {
            Console.WriteLine("{0} won!", playerTwo.playerName);
            return String.Format("{0} won!", playerTwo.playerName);
        }
    }

    public void Play()
    {
        // Clear the console before the round
        Clear();

        // FirstPlayer makes his choice with data validation
        playerOne.GetInput(inputTable);

        // Clear the console so the SecondPlayer doesn't see what the FirstPlayer chose
        Clear();

        // SecondPlayer makes his choice with data validation
        playerTwo.GetInput(inputTable);

        // Clear the console before announcing the winner
        Clear();

        // Check and display the result
        string gameResult = DetermineWinner(playerOne, playerTwo);

        // Add data to GamesRecord
        gamesRecord.AddRecord(playerOne.lastInput, playerTwo.lastInput, gameResult);

        // Ask the players if they want to continue
        WriteLine("Do you want to play another round? [y]");
        if (ReadKey(true).Key == ConsoleKey.Y)
        {
            Play();
        }
    }


}