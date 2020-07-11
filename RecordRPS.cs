using System;
using System.Collections.Generic;
using System.Text;

namespace Kacper_Borowski
{
    class RecordRPS : IRecord
    {
        string playerOneChoice;
        string playerTwoChoice;
        string result;

        public RecordRPS(string playerOneChoice, string playerTwoChoice, string result)
        {
            this.playerOneChoice = playerOneChoice;
            this.playerTwoChoice = playerTwoChoice;
            this.result = result;
        }

        override public string ToString()
        {
            return string.Format("{0,20} : {1,-20}", playerOneChoice + " vs " + playerTwoChoice, result);
        }

    }
}
