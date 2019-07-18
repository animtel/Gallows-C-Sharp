using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_Game
{
    /// <summary>
    /// Game result enumeration
    /// </summary>
    public enum GAMERESULT
    {
        WIN,// Game is finished and player won the game
        LOSE,// Game is finished and player lose the game
        CONTINUE,// Continue play
    }
}
