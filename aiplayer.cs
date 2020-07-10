using System;
using System.Collections.Generic;
using System.Linq;

class AIPlayer : Player
{
    Random random;

    public AIPlayer()
    {
        this.playerName += " [AI Player]";
        random = new Random();
    }

    override public void GetInput(Dictionary<string, string> inputTable)
    {
        lastInput = inputTable.ElementAt(random.Next(inputTable.Count)).Value;
    }
}