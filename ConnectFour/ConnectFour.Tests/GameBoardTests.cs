using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.Tests
{
    class GameBoardTests
    {
        [Fact]
        public void SetStoneInInvalidColumn()
        {
            var b = new GameBoard();
            Assert.Throws < ArgumentOutOfRangeException(b.setStone(99) >;
        }
    }
}
