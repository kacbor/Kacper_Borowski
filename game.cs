using System;
using System.Collections.Generic;
using System.Text;

namespace Kacper_Borowski
{
   abstract class Game
    {
        protected Player playerOne, playerTwo;
        protected Dictionary<string, string> inputTable;
        public GamesRecord gamesRecord;
        public abstract void Play();

    }
}
