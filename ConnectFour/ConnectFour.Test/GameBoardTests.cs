using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConnectFour.Tests
{
    public class GameBoardTests
    {
        [Fact]
        public void SetStoneInInvalidColumn()
        {
            var b = new GameBoard();
            var previousPlayer = b.playerOne;
            Assert.Throws < ArgumentOutOfRangeException>(()=>b.SetStone(99));
            Assert.Equal(previousPlayer, b.playerOne);
        }
        [Fact]
        public void NextPlayerAfterSuccessfulMove()
        {
            var b = new GameBoard();
            var previousPlayer = b.playerOne;
            b.SetStone(5);
            Assert.NotEqual(previousPlayer, b.playerOne);
        }

        [Fact]
        public void NoWinnerAfterSingleMove()
        {
            var b = new GameBoard();
            var winner= b.SetStone(5);
            Assert.Equal(winner, 0);
        }
        [Fact]
        public void SetStoneInFullColumn()
        {
            var b = new GameBoard();
            for(var i = 0; i < 6; i++)
            {
                b.SetStone(0);
            }
            var previousPlayer = b.playerOne;
            Assert.Throws<InvalidOperationException>(() => b.SetStone(0));
            Assert.Equal(previousPlayer, b.playerOne);
        }
        [Fact]
        public void VerticalWin()
        {
            var b = new GameBoard();
            for (var i = 0; i < 3; i++)
            {
                b.SetStone(0);
                b.SetStone(1);

            }
            var result=b.SetStone(0);
            Assert.Equal(1, result);
        }
        [Fact]
        public void HorizontalWin()
        {
            var b = new GameBoard();
            for (byte i = 0; i < 3; i++)
            {
                Assert.Equal(0, b.SetStone(i));
                Assert.Equal(0, b.SetStone(i));

            }
            var result = b.SetStone(3);
            Assert.Equal(1, result);
        }
        [Fact]
        public void DiagonalWinLLTUR()
        {
            var b = new GameBoard();
            Assert.Equal(0, b.SetStone(0));//1
            Assert.Equal(0, b.SetStone(1));//2
            Assert.Equal(0, b.SetStone(1));//1
            Assert.Equal(0, b.SetStone(2));//2
            Assert.Equal(0, b.SetStone(2));//1
            Assert.Equal(0, b.SetStone(3));//2
            Assert.Equal(0, b.SetStone(2));//1
            Assert.Equal(0, b.SetStone(3));//2
            Assert.Equal(0, b.SetStone(3));//1
            Assert.Equal(0, b.SetStone(5));//2
            //Assert.Equal(0, b.SetStone(3));//1
            var result = b.SetStone(3);//1
            Assert.Equal(1, result);
        }
        [Fact]
        public void DiagonalWinLRTUL()
        {
            var b = new GameBoard();
            Assert.Equal(0, b.SetStone(3));//1
            Assert.Equal(0, b.SetStone(2));//2
            Assert.Equal(0, b.SetStone(2));//1
            Assert.Equal(0, b.SetStone(1));//2
            Assert.Equal(0, b.SetStone(1));//1
            Assert.Equal(0, b.SetStone(0));//2
            Assert.Equal(0, b.SetStone(1));//1
            Assert.Equal(0, b.SetStone(0));//2
            Assert.Equal(0, b.SetStone(0));//1
            Assert.Equal(0, b.SetStone(6));//2
            //Assert.Equal(0, b.SetStone(0));//1
            var result = b.SetStone(0);//1
            Assert.Equal(1, result);
        }
        [Fact]
        public void Draw()
        {
            var b = new GameBoard();
            Assert.Equal(0, b.SetStone(0));
            Assert.Equal(0, b.SetStone(1));
            Assert.Equal(0, b.SetStone(0));
            Assert.Equal(0, b.SetStone(1));
            Assert.Equal(0, b.SetStone(0));
            Assert.Equal(0, b.SetStone(1));
            Assert.Equal(0, b.SetStone(2));
            Assert.Equal(0, b.SetStone(3));
            Assert.Equal(0, b.SetStone(2));
            Assert.Equal(0, b.SetStone(3));
            Assert.Equal(0, b.SetStone(2));
            Assert.Equal(0, b.SetStone(3));
            Assert.Equal(0, b.SetStone(6));
            Assert.Equal(0, b.SetStone(0));
            Assert.Equal(0, b.SetStone(1));
            Assert.Equal(0, b.SetStone(0));
            Assert.Equal(0, b.SetStone(1));
            Assert.Equal(0, b.SetStone(0));
            Assert.Equal(0, b.SetStone(1));
            Assert.Equal(0, b.SetStone(2));
            Assert.Equal(0, b.SetStone(3));
            Assert.Equal(0, b.SetStone(2));
            Assert.Equal(0, b.SetStone(3));
            Assert.Equal(0, b.SetStone(2));
            Assert.Equal(0, b.SetStone(3));
            Assert.Equal(0, b.SetStone(5));
            Assert.Equal(0, b.SetStone(4));
            Assert.Equal(0, b.SetStone(5));
            Assert.Equal(0, b.SetStone(4));
            Assert.Equal(0, b.SetStone(5));
            Assert.Equal(0, b.SetStone(4));
            Assert.Equal(0, b.SetStone(4));
            Assert.Equal(0, b.SetStone(5));
            Assert.Equal(0, b.SetStone(4));
            Assert.Equal(0, b.SetStone(5));
            Assert.Equal(0, b.SetStone(4));
            Assert.Equal(0, b.SetStone(5));
            Assert.Equal(0, b.SetStone(6));
            Assert.Equal(0, b.SetStone(6));
            Assert.Equal(0, b.SetStone(6));
            Assert.Equal(0, b.SetStone(6));
            var result = b.SetStone(6);//1
            Assert.Equal(3, result);
        }
    }
}
