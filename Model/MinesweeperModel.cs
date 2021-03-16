using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LifeSim.Model
{
    public class MinesweeperModel
    {
        #region Fields

        private Random rnd;
        private List<(int,int)> mines;
        private List<(int,int)> checkedFields;
        private List<(int, int)> markedFields;
        private int marks;

        #endregion

        #region Properties

        public Field[,] MineField { get; private set; }

        public bool Recon { get; set; }

        public bool gameOver { get; private set; }

        #endregion

        #region Events

        public event EventHandler<EventArgs> GameOverEvent;

        public event EventHandler<EventArgs> GameWonEvent;

        #endregion

        #region Constructor

        public MinesweeperModel()
        {
            rnd = new Random();
            MineField = new Field[8,8];
            checkedFields = new List<(int,int)>();
            markedFields = new List<(int, int)>();
            Recon = true;
            marks = 15;
            gameOver = false;
        }

        #endregion

        #region Public methods

        public void newGame(int fieldNum)
        {
            mines = new List<(int,int)>();
            int randomX;
            int randomY;
            int numberX = fieldNum / 8;
            int numberY = fieldNum % 8;
            for (int i = 0; i < 15; i++)
            {
                do
                {
                    randomX = rnd.Next(0, 8);
                    randomY = rnd.Next(0, 8);
                } while (randomAdjacent(randomX, randomY, numberX, numberY) || mines.Contains((randomX,randomY)));
                Debug.WriteLine(randomX + " " + randomY);
                mines.Add((randomX,randomY));
            }
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (mines.Contains((i,j)))
                    {
                        MineField[i,j] = new Field(false, true, 0, false);
                    }
                    else if (i == fieldNum)
                    {
                        MineField[i, j] = new Field(true, false, checkAdjacentFieldsForMines(i, j), false);
                    }
                    else
                    {
                        MineField[i, j] = new Field(false, false, checkAdjacentFieldsForMines(i, j), false);
                    }
                }
            }
            revealFields(numberX, numberY);
            checkedFields.Clear();
        }

        public void recon(int fieldNum)
        {
            int numberX = fieldNum / 8;
            int numberY = fieldNum % 8;
            if (MineField[numberX, numberY].Revealed || MineField[numberX, numberY].Marked)
                return;
            if (MineField[numberX, numberY].Mine)
            {
                gameOver = true;
                OnGameOverEvent();
            }
            revealFields(numberX, numberY);
        }

        public void mark(int fieldNum)
        {
            Debug.WriteLine("Before: " + marks);
            int numberX = fieldNum / 8;
            int numberY = fieldNum % 8;
            if (MineField[numberX, numberY].Revealed || marks == 0)
            {
                Debug.WriteLine("After: " + marks);
                return;
            }
            if (MineField[numberX, numberY].Marked)
            {
                MineField[numberX, numberY].Marked = false;
                marks++;
                Debug.WriteLine("After: " + marks);
                return;
            }
            MineField[numberX, numberY].Marked = true;
            markedFields.Add((numberX, numberY));
            marks--;
            Debug.WriteLine("After: " + marks);
            if (marks == 0 && mines.All(markedFields.Contains))
            {
                gameOver = true;
                OnGameWonEvent();
            }
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
            if (i < 0 || i > 7 || j < 0 || j > 7)
                return;

            if (!checkedFields.Contains((i,j)) && !MineField[i,j].Mine)
            {
                revealFields(i, j);
            }
        }

        private bool randomAdjacent(int randX, int randY, int numX, int numY)
        {
            return ((randX == numX && randY == numY) || (randX == numX - 1 && randY == numY - 1) || (randX == numX - 1 && randY == numY) || (randX == numX - 1 && randY == numY + 1) || (randX == numX && randY == numY - 1) || (randX == numX && randY == numY + 1) || (randX == numX + 1 && randY == numY + 1) || (randX == numX + 1 && randY == numY) || (randX == numX + 1 && randY == numY - 1));
        }

        #endregion

        #region Private event methods

        private void OnGameOverEvent()
        {
            GameOverEvent?.Invoke(this, new EventArgs());
        }

        private void OnGameWonEvent()
        {
            GameWonEvent?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
