using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chessboard
{
    [TestClass]
    public class ChessboardTest
    {
        [TestMethod]
        public void NumberOFSquaresOnTheChessboard()
        {
            Assert.AreEqual(5, DetermineTheSquaresOnTheChessboard(2));
        }
        int DetermineTheSquaresOnTheChessboard(int lengthChessboard) {
            int numberOfSquares = 0;
            for (int i = 1; i <= lengthChessboard; i++)
                numberOfSquares += i * i;
            return numberOfSquares;
        }
    }
}
