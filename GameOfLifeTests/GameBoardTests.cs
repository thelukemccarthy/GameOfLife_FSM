using System;
using GameOfLife;
using GameOfLife.Exceptions;
using NUnit.Framework;

namespace GameOfLifeTests
{
    [TestFixture]
    public class GameBoardTests
    {
        [Test]
        [ExpectedException(typeof(OutOfBoundsOfGameBoard))]
        public void GivenAStandardGameBoardWhenGettingACellOutsideTheBoundsOfTheBoardShouldThrowAnError()
        {
            var gameBoard = GetGameBoard();
            gameBoard.GetCell(5, 5);
        }

        [Test]
        public void GivenValidPointsOnTheGameBoardWhenGetCellIsCalledThenACellShouldBeReturned()
        {
            var gameBoard = GetGameBoard();
            var cell = gameBoard.GetCell(1, 1);

            Assert.IsNotNull(cell);
            Assert.IsInstanceOf<Cell>(cell);
        }

        [Test]
        public void GivenValidPointsOnTheGameBoardWhenGettingACellFromTheSamePositionThenTheInstanceOfACellShouldBeReturned()
        {
            var gameBoard = GetGameBoard();
            var cell1 = gameBoard.GetCell(1, 1);
            var cell2 = gameBoard.GetCell(1, 1);

            Assert.AreSame(cell1, cell2);
        }

        [TestCase(5, 0)]
        [TestCase(0, 5)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [ExpectedException(typeof(OutOfBoundsOfGameBoard))]
        public void GivenAnInalidPositionOnTheBoardWhenGetNeighboursIsCalledThenAErrorShouldBeThrown(int x, int y)
        {
            var gameBoard = GetGameBoard();
            gameBoard.GetNeighbourCells(x, y);
        }

        [Test]
        public void GivenACornerPositionOnTheBoardWhenGetNeighboursIsCalledAListOfThreeNeighbourCellsShouldBeReturned()
        {
            var gameBoard = GetGameBoard();
            var neighbourCells = gameBoard.GetNeighbourCells(0, 0);
            const int expected = 3;

            Assert.AreEqual(expected, neighbourCells.Count);
        }

        [Test]
        public void GivenASidePositionOnTheBoardWhenGetNeighboursIsCalledAListOfFiveNeighbourCellsShouldBeReturned()
        {
            var gameBoard = GetGameBoard();
            var neighbourCells = gameBoard.GetNeighbourCells(0, 1);
            const int expected = 5;

            Assert.AreEqual(expected, neighbourCells.Count);
        }

        [Test]
        public void GivenAMiddlePositionOnTheBoardWhenGetNeighboursIsCalledAListOfNineNeighbourCellsShouldBeReturned()
        {
            var gameBoard = GetGameBoard();
            var neighbourCells = gameBoard.GetNeighbourCells(1, 1);
            const int expected = 8;

            Assert.AreEqual(expected, neighbourCells.Count);
        }

        [Test]
        public void GivenACellWithNoAliveNeighboursWhenGetNumberOfAliveNeighboursIsCalledZeroShouldBeReturned()
        {
            var gameBoard = GetGameBoard();
            const int expected = 0;
            int actual = gameBoard.GetNumberOfAliveNeighbours(1, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void GivenACellWithAliveNeighboursWhenGetNumberOfAliveNeighboursIsCalledTheCorrectNumberShouldBeReturned(int expected)
        {
            var gameBoard = GetGameBoard();
            const int x = 1;
            const int y = 1;
            MakeCellNeighboursAlive(gameBoard, x, y, expected);
            int actual = gameBoard.GetNumberOfAliveNeighbours(x, y);

            Assert.AreEqual(expected, actual);
        }

        private GameBoard GetGameBoard()
        {
            return new GameBoard(5, 5);
        }

        private void MakeCellNeighboursAlive(GameBoard gameBoard, int x, int y, int numberOfAliveNeighbours)
        {
            var neighbourCells = gameBoard.GetNeighbourCells(x, y);

            if (numberOfAliveNeighbours > neighbourCells.Count)
            {
                throw new Exception("Not enough neighbours to Alive");
            }

            for (int i = 0; i < numberOfAliveNeighbours; i++)
            {
                neighbourCells[i].CellState = CellStates.Alive;
            }
        }

        private GameBoard CreateInitialGameBoard()
        {
            var gameBoard = new GameBoard(5, 5);

            gameBoard.GetCell(0, 2).CellState = CellStates.Alive;
            gameBoard.GetCell(0, 3).CellState = CellStates.Alive;
            gameBoard.GetCell(1, 1).CellState = CellStates.Alive;
            gameBoard.GetCell(1, 2).CellState = CellStates.Alive;
            gameBoard.GetCell(1, 3).CellState = CellStates.Alive;
            gameBoard.GetCell(2, 2).CellState = CellStates.Alive;
            gameBoard.GetCell(3, 2).CellState = CellStates.Alive;
            gameBoard.GetCell(4, 2).CellState = CellStates.Alive;
            gameBoard.GetCell(4, 4).CellState = CellStates.Alive;

            return gameBoard;
        }
    }
}
