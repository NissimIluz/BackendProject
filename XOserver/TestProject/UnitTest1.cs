using NUnit.Framework;
using Contracts;
using XOboardRandomPlayer;
using XOBoardScanPlayer;
using System;
using XOBoardMatImpl;

namespace TestProject2
{
    public class Tests
    {
        IXOBoard board;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PutOnEmptyCell()
        {

            var actual = board.Put(XorO.X, 0, 1);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public void PutOnOccupiedCell()
        {
            board.Put(XorO.X, 0, 0);
            var actual = board.Put(XorO.X, 0, 0);
            Assert.AreEqual(false, actual);
        }
        [Test]
        public void PutOnIndexOutOfRange()
        {
            bool actual1, actual2, actual3, actual4;
            try
            {
                actual1 = board.Put(XorO.X, -1, 0);
            }
            catch (System.IndexOutOfRangeException)
            {
                actual1 = true;
            }
            try
            {
                actual2 = board.Put(XorO.X, 0, -1);
            }
            catch (System.IndexOutOfRangeException)
            {
                actual2 = true;
            }
            try
            {
                actual3 = board.Put(XorO.X, 0, board.Size);
            }
            catch (System.IndexOutOfRangeException)
            {
                
                actual3 = true;
            }
            try
            {
                actual4 = board.Put(XorO.X, board.Size, 0);
            }
            catch (System.IndexOutOfRangeException)
            {
                actual4 = true;
            }
            Assert.AreEqual(false, actual1);
            Assert.AreEqual(false, actual2);
            Assert.AreEqual(false, actual3);
            Assert.AreEqual(false, actual4);
        }
        [Test]
        public void XOBoardMatImpl2()
        {
            int i;
            int j;
            XOBoard temp = new XOBoard();
            Assert.AreEqual(true, temp.Size == 3);
            
            for ( i = 0; i < temp.Size-1; i++)
            {
                temp.Put(XorO.X, i, i);
                Assert.AreEqual(true, temp.getStatus() == Status.None);
            }
    
            temp.Put(XorO.X, i, i);
            Assert.AreEqual(true, temp.getStatus() == Status.X);
            temp = new XOBoard(5);
            for ( i = 0; i < temp.Size -1; i++)
            {
                temp.Put(XorO.X, i, temp.Size - 1 - i);
                Assert.AreEqual(true, temp.getStatus() == Status.None);
            }

            temp.Put(XorO.X, i, temp.Size - 1 - i);
            Assert.AreEqual(true, temp.getStatus() == Status.X); 
            for ( i = 0; i < temp.Size; i++)
            {
                temp = new XOBoard(4);
                for ( j = 0; j < temp.Size-1 ; j++)
                {
                    temp.Put(XorO.X, i, j);
                    Assert.AreEqual(true, temp.getStatus() == Status.None);
                }
    
                temp.Put(XorO.X, i, j);
                Assert.AreEqual(true, temp.getStatus() == Status.X);
            }
            int size = 6;
            for ( i = 0; i < size; i++)
            {
                temp = new XOBoard(size);
                for ( j = 0; j < temp.Size-1; j++)
                {
                    temp.Put(XorO.X, j, i);
                    Assert.AreEqual(true, temp.getStatus() == Status.None);
                }
    
                temp.Put(XorO.X, j, i);
                bool x = temp.getStatus() == Status.X;
                Assert.AreEqual(true, x);
            }

            temp = new XOBoard(5);
            for ( i = 0; i < temp.Size; i++)
            {
                for ( j = 0; j < temp.Size; j++)
                    if (j % 2 == 0)
                        temp.Put(XorO.X, i, j);
                    else
                        temp.Put(XorO.O, i, j);
            }
            Assert.AreEqual(true, temp.getStatus() == Status.Draw);
        }

        [Test]
        public void ScanPlayerTest()
        {
            IPlayer player = new ScanPlayer(XorO.X);
            IXOBoard tempBoard = new XOBoard(2);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(true, player.makeMove(tempBoard));
            }
            Assert.AreEqual(false, player.makeMove(tempBoard));
        }
        [Test]
        public void RandomPlayerTest()
        {
            IPlayer player = new RandomPlayer(XorO.X);
            IXOBoard tempBoard = new XOBoard(1);
            Assert.AreEqual(true, player.makeMove(tempBoard));
            Assert.AreEqual(false, player.makeMove(tempBoard));
            tempBoard = new XOBoard(3);
            Assert.AreEqual(true, player.makeMove(tempBoard));

        }
    }
}