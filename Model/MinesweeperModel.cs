using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LifeSim.Model
{
    public class MinesweeperModel
    {
        #region Fields

        private Random rnd;
        private List<(int,int)> mines;
        private List<(int,int)> checkedFields;

        #endregion

        #region Properties

        public Field[,] MineField { get; set; }

        #endregion

        #region Constructor

        public MinesweeperModel()
        {
            rnd = new Random();
            MineField = new Field[8,8];
            checkedFields = new List<(int,int)>();
        }

        #endregion

        #region Public methods

        public void newGame(int number)
        {
            mines = new List<(int,int)>();
            int randomX;
            int randomY;
            int numberX = number / 8;
            int numberY = number % 8;
            for (int i = 0; i < 15; i++)
            {
                do
                {
                    randomX = rnd.Next(0, 8);
                    randomY = rnd.Next(0, 8);
                } while (randomAdjacent(randomX, randomY, numberX, numberY));
                mines.Add((randomX,randomY));
            }
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (mines.Contains((i,j)))
                    {
                        MineField[i,j] = new Field(false, true, 0);
                    }
                    else if (i == number)
                    {
                        MineField[i, j] = new Field(true, false, checkAdjacentFieldsForMines(i, j));
                    }
                    else
                    {
                        MineField[i, j] = new Field(false, false, checkAdjacentFieldsForMines(i, j));
                    }
                }
            }
            revealFields(numberX, numberY);
            checkedFields.Clear();
        }

        #endregion

        #region Private methods

        private int checkAdjacentFieldsForMines(int i, int j)
        {
            int adjacentMines = 0;
            adjacentMines += checkForMine(i - 1, j - 1);
            adjacentMines += checkForMine(i - 1, j);
            adjacentMines += checkForMine(i - 1, j + 1);
            adjacentMines += checkForMine(i, j - 1);
            adjacentMines += checkForMine(i, j + 1);
            adjacentMines += checkForMine(i + 1, j - 1);
            adjacentMines += checkForMine(i + 1, j);
            adjacentMines += checkForMine(i + 1, j + 1);
            return adjacentMines;
        }

        private int checkForMine(int i, int j)
        {
            if (mines.Contains((i,j)))
            {
                return 1;
            }
            return 0;
        }

        private void revealFields(int i, int j)
        {
            if (i < 0 || i > 7 || j < 0 || j > 7)
                return;

            checkedFields.Add((i,j));
            MineField[i,j].Revealed = true;
            if (MineField[i,j].MinesInProximity == 0)
            {
                revealRecursion(i - 1, j - 1);
                revealRecursion(i - 1 , j);
                revealRecursion(i - 1, j + 1);
                revealRecursion(i, j - 1);
                revealRecursion(i, j + 1);
                revealRecursion(i + 1, j - 1);
                revealRecursion(i + 1, j);
                revealRecursion(i + 1, j + 1);
            }
        }

        private void revealRecursion(int i, int j)
        {
            if (!checkedFields.Contains((i,j)))
            {
                revealFields(i, j);
            }
        }

        private bool randomAdjacent(int randX, int randY, int numX, int numY)
        {
            return ((randX == numX && randY == numY) || (randX == numX - 1 && randY == numY - 1) || (randX == numX - 1 && randY == numY) || (randX == numX - 1 && randY == numY + 1) || (randX == numX && randY == numY - 1) || (randX == numX && randY == numY + 1) || (randX == numX + 1 && randY == numY + 1) || (randX == numX + 1 && randY == numY) || (randX == numX + 1 && randY == numY - 1));
        }

        #endregion
    }
}
