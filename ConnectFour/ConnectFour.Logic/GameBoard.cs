using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.Logic
{
    public class GameBoard
    {
        private byte[,] board=new byte[7,6];
        internal bool playerOne = true;
        private int counter = 0;
        private byte CheckForVerticalWin(byte column, byte row)
        {
            if (row < 3)
            {
                return 0;
            }
            var player = board[column, row];
            for(var i = 0; i < 3; i++)
            {
                if (board[column, row - i - 1] != player)
                {
                    return 0;
                }
            }
            return player;
        }
        private byte CheckForHorizontalWin(byte row)
        {
            byte player=0;
            byte count=0;
            for(var i = 0; i < 7; i++)
            {
                if (board[i, row] == player)
                {
                    count++;
                    if (count == 4)
                    {
                        return player;
                    }
                }
                else
                {
                    player = board[i, row];
                    count = 1;
                }
            }
            return 0;
        }
        
        //Lower right to upper left
        private byte CheckForDiagonalLRTULWin(byte column, byte row)
        {
            var diff = Math.Min(6-column, row);
            var startColumn = column + diff;
            var startRow = row - diff;
            var count = 0;
            byte player = 0;
            for (var i = 0; startColumn - i >= 0 && startRow + i < 6; i++)
            {

                if (board[startColumn - i, startRow + i] == player)
                {
                    count++;
                    if (count == 4)
                    {
                        return player;
                    }
                }
                else
                {
                    player = board[startColumn - i, startRow + i];
                    count = 1;
                }
            }
            return 0;
        }
        //Lower left to upper right
        private byte CheckForDiagonalLLTURWin(byte column, byte row)
        {
            var diff = Math.Min(column, row);
            var startColumn = column - diff;
            var startRow = row - diff;
            var count = 0;
            byte player = 0;
            for(var i = 0; startColumn + i < 7 && startRow + i < 6;i++)
            {
                
                if (board[startColumn + i, startRow + i] == player&& player!=0)
                {
                    count++;
                    if (count == 4)
                    {
                        return player;
                    }
                }
                else
                {
                    player = board[startColumn + i, startRow + i];
                    count = 1;
                }
            }
            return 0;
        }
        private byte CheckForDiagonalWin(byte column, byte row)
        {
            var winner = CheckForDiagonalLLTURWin(column, row);
            if (winner != 0)
            {
                return winner;
            }
            winner = CheckForDiagonalLRTULWin(column,row);
            if (winner != 0)
            {
                return winner;
            }
            return 0;
        }
        private byte CheckForWin(byte column, byte row)
        {
            var winner = CheckForVerticalWin(column, row);
            if (winner != 0)
            {
                return winner;
            }
            winner = CheckForHorizontalWin(row);
            if (winner != 0)
            {
                return winner;
            }
            winner = CheckForDiagonalWin(column, row);
            if (winner != 0)
            {
                return winner;
            }
            return winner;
        }
        public byte SetStone(byte column)
        {
            
            if (column > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            for(byte row = 0; row < 6; row++)
            {
                if (board[column, row] == 0)
                {
                    board[column, row] = playerOne ? (byte)1 : (byte)2;
                    playerOne = !playerOne;
                    counter++;
                    if (counter != 6 * 7)
                    {
                        return CheckForWin(column, row);
                    }
                    else
                    {
                        var winner=CheckForWin(column, row);
                        if (winner != 0)
                        {
                            return winner;
                        }
                        return 3;
                    }
                }
            }
            throw new InvalidOperationException("Column if full");
        }
    }
}
