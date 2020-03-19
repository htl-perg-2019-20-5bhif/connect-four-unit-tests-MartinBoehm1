using ConnectFour.Logic;
using System;

namespace ConnectFour.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard gb = new GameBoard();
            var Result=0;
            while (Result == 0)
            {
                Result = (gb.SetStone(byte.Parse(Console.ReadLine())));
                
            }
            if(Result==3)
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine(Result + " won");
            }
        }
    }
}
