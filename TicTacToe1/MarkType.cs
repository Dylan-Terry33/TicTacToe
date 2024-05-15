using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe1
{
    // The type of value a cell in the game is currently at
    public enum MarkType
    {
        // cell is unclicked
        Free,
        //cell is an "O"
        Nought,
        //cell is an "X"
        Cross
    }
}
