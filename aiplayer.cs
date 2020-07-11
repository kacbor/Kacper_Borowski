using System;
using System.Collections.Generic;
using System.Linq;

class AIPlayer : Player
{
    Random random;

    public AIPlayer() : base(false)
    {
        this.playerName = "AI Player";
        random = new Random();
    }


    override public void GetInput(Dictionary<string, string> inputTable)
    {
        LastInput = inputTable.ElementAt(random.Next(inputTable.Count)).Value;
    }
}