using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Exceptions;

namespace GameOfLife
{
    public class GameBoard
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Cell[,] _gameBoard;

        public GameBoard(int width, int height)
        {
            _width = width;
            _height = height;
            _gameBoard = new Cell[_width, _height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _gameBoard[x,y] = new Cell();
                }
            }
        }

        public GameBoard GetNextGeneration(ICellStateMachine cellStateMachine)
        {
            var gameBoard = new GameBoard(_width, _height);

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var cell = GetCell(x, y);
                    var nextCellState = cellStateMachine.GetNextState(cell.CellState, GetNumberOfAliveNeighbours(x, y));

                    gameBoard._gameBoard[x, y].CellState = nextCellState;
                }
            }

            return gameBoard;
        }

        public Cell GetCell(int x, int y)
        {
            if (CoordinatesOutsideTheBoundsOfTheGameBoard(x, y))
                throw new OutOfBoundsOfGameBoard();

            return _gameBoard[x,y];
        }

        public int GetNumberOfAliveNeighbours(int x, int y)
        {
            return (from aliveCells in GetNeighbourCells(x, y)
                where aliveCells.CellState == CellStates.Alive
                select aliveCells).ToList().Count;
        }

        public IList<Cell> GetNeighbourCells(int x, int y)
        {
            if (CoordinatesOutsideTheBoundsOfTheGameBoard(x, y))
                throw new OutOfBoundsOfGameBoard();

            var neighbours = new List<Cell>();

            for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
            {
                for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
                {
                    if (!CoordinatesOutsideTheBoundsOfTheGameBoard(neighbourX, neighbourY)
                        && IsCellNeighbour(x, y, neighbourX, neighbourY))
                            neighbours.Add(_gameBoard[neighbourX, neighbourY]);
                }
            }

            return neighbours;
        }

        private bool CoordinatesOutsideTheBoundsOfTheGameBoard(int x, int y)
        {
            return (x >= _width || x < 0 || y >= _height || y < 0);
        }

        private bool IsCellNeighbour(int startX, int startY, int neighbourX, int neighbourY)
        {
            var diffBetweenXPoints = Math.Abs(startX - neighbourX);
            var diffBetweenYPoints = Math.Abs(startY - neighbourY);
            if (diffBetweenXPoints > 1 || diffBetweenYPoints > 1
                || (diffBetweenXPoints == 0 && diffBetweenYPoints == 0))
            {
                return false;
            }

            return true;
        }
    }
}
