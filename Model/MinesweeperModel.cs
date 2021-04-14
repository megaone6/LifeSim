using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LifeSim.Model
{
    /// <summary>
    /// Minesweeper logikájának típusa.
    /// </summary>
    public class MinesweeperModel
    {
        #region Fields

        private Random rnd; // véletlenszám-generátor
        private List<(int, int)> mines; // aknák helyzetének listája
        private List<(int, int)> checkedFields; // felfedett mezők listája
        private List<(int, int)> markedFields; // megjelölt mezők listája
        private int marks; // megjelölések száma

        #endregion

        #region Properties

        /// <summary>
        /// Játékmező.
        /// </summary>
        public Field[,] MineField { get; private set; }

        /// <summary>
        /// Vége van-e a játéknak.
        /// </summary>
        public bool gameOver { get; private set; }

        #endregion

        #region Events

        /// <summary>
        /// Játék elvesztésének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> GameOverEvent;

        /// <summary>
        /// Játék megnyerésének eseménye.
        /// </summary>
        public event EventHandler<EventArgs> GameWonEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// Minesweeper játék példányosítása.
        /// </summary>
        public MinesweeperModel()
        {
            rnd = new Random();
            MineField = new Field[8,8];
            checkedFields = new List<(int,int)>();
            markedFields = new List<(int, int)>();
            marks = 15;
            gameOver = false;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Új játék kezdése.
        /// </summary>
        /// <param name="fieldNum">A mező száma, ahova kattintottunk.</param>
        public void newGame(int fieldNum)
        {
            mines = new List<(int,int)>();
            int randomX;
            int randomY;
            int numberX = fieldNum / 8;
            int numberY = fieldNum % 8;
            for (int i = 0; i < 15; i++) // legenerálja az aknák pozícióját
            {
                do
                {
                    randomX = rnd.Next(0, 8);
                    randomY = rnd.Next(0, 8);
                } while (randomAdjacent(randomX, randomY, numberX, numberY) || mines.Contains((randomX,randomY)));
                mines.Add((randomX,randomY));
            }
            for (int i = 0; i < 8; i++) // legenerálja a mezőket
            {
                for(int j = 0; j < 8; j++)
                {
                    if (mines.Contains((i,j))) // ha az adott mezőn akna van, akkor azzal generálja le
                    {
                        MineField[i,j] = new Field(false, true, 0, false);
                        Debug.WriteLine(i + " " + j);
                    }
                    else if (i == fieldNum) // a mezőt, amire kattintottunk felfedi
                    {
                        MineField[i, j] = new Field(true, false, checkAdjacentFieldsForMines(i, j), false);
                    }
                    else // különben a mező felfedetlen lesz
                    {
                        MineField[i, j] = new Field(false, false, checkAdjacentFieldsForMines(i, j), false);
                    }
                }
            }
            revealFields(numberX, numberY); // felfedi azokat a kattintott mezővel szomszédos mezőket, amiket kell
            checkedFields.Clear(); 
        }

        /// <summary>
        /// Mezők felfedése.
        /// </summary>
        /// <param name="fieldNum">A mező száma, ahova kattintottunk.</param>
        public void recon(int fieldNum)
        {
            int numberX = fieldNum / 8;
            int numberY = fieldNum % 8;
            if (MineField[numberX, numberY].Revealed || MineField[numberX, numberY].Marked) // ha a mezőt már felfedtük, vagy megjelöltük, akkor visszatérünk
                return;
            if (MineField[numberX, numberY].Mine) // ha a kattintott mezőn akna van, akkor vesztettünk
            {
                gameOver = true;
                OnGameOverEvent();
            }
            revealFields(numberX, numberY); // felfedi azokat a kattintott mezővel szomszédos mezőket, amiket kell
        }

        /// <summary>
        /// Mezők megjelölése.
        /// </summary>
        /// <param name="fieldNum">A mező száma, ahova kattintottunk.</param>
        public void mark(int fieldNum)
        {
            Debug.WriteLine("Before: " + marks);
            int numberX = fieldNum / 8;
            int numberY = fieldNum % 8;
            if (MineField[numberX, numberY].Marked) // ha a mezőt már megjelöltük, akkor megszüntetjük a jelölést, és vissza is kapjuk
            {
                MineField[numberX, numberY].Marked = false;
                marks++;
                Debug.WriteLine("After: " + marks);
                return;
            }
            if (MineField[numberX, numberY].Revealed || marks == 0) // ha a mezőt már felfedtük, vagy már nincs több jelölésünk, akkor visszatérünk
            {
                Debug.WriteLine("After: " + marks);
                return;
            }
            MineField[numberX, numberY].Marked = true; // különben megjelöljük a mezőt
            markedFields.Add((numberX, numberY)); // bekerül a megjelölt mezők listájába
            marks--; // csökken a hátralévő jelöléseink száma
            Debug.WriteLine("After: " + marks);
            if (marks == 0 && mines.All(markedFields.Contains)) // ha már nincs több jelölésünk és minden megjelölt mezőn akna van, akkor megnyertük a játékot
            {
                gameOver = true;
                OnGameWonEvent();
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Megadja, hogy egy adott mező mellett hány akna van.
        /// </summary>
        /// <param name="i">A mező pozíciója az Y-tengelyen.</param>
        /// <param name="j">A mező pozíciója az X-tengelyen.</param>
        /// <returns>Az adott mező melletti aknák száma.</returns>
        private int checkAdjacentFieldsForMines(int i, int j)
        {
            int adjacentMines = 0;
            // minden mellette lévő mezőre meghívjuk a checkForMine függvényt
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

        /// <summary>
        /// Megadja, hogy az adott mezőn van-e akna.
        /// </summary>
        /// <param name="i">A mező pozíciója az Y-tengelyen.</param>
        /// <param name="j">A mező pozíciója az X-tengelyen.</param>
        /// <returns>1, ha van a mezőn akna, 0, ha nincs.</returns>
        private int checkForMine(int i, int j)
        {
            if (mines.Contains((i,j))) // ha az aknák listája tartalmazza a koordinátákat, akkor 1 a visszatérési érték, különben 0
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Felfedi a megadott mezőt.
        /// </summary>
        /// <param name="i">A mező pozíciója az Y-tengelyen.</param>
        /// <param name="j">A mező pozíciója az X-tengelyen.</param>
        private void revealFields(int i, int j)
        {
            if (i < 0 || i > 7 || j < 0 || j > 7) // ha a mező kívül esik a pályán, akkor visszatér (ez szükséges, mivel többször isrekurzívan fogjuk meghívni a függvényt)
                return;

            checkedFields.Add((i,j));
            MineField[i,j].Revealed = true;

            if (MineField[i,j].MinesInProximity == 0) // ha nincs akna a közelben, akkor a szomszédos mezőket felfedi
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

        /// <summary>
        /// Az előző függvény rekurziójáért felel.
        /// </summary>
        /// <param name="i">A mező pozíciója az Y-tengelyen.</param>
        /// <param name="j">A mező pozíciója az X-tengelyen.</param>
        private void revealRecursion(int i, int j)
        {
            if (i < 0 || i > 7 || j < 0 || j > 7) // ha a mező kívül esik a pályán, akkor visszatér
                return;

            if (!checkedFields.Contains((i,j)) && !MineField[i,j].Mine && !MineField[i, j].Marked) // ha a mezőt még nem fedtük fel, nem jelöltük meg és nem akna van rajta, akkor felfedi
            {
                revealFields(i, j);
            }
        }

        /// <summary>
        /// Ez a függvény azért felel, hogy a random-generátor ne generáljon arra a mezőre aknát, amire először kattintunk.
        /// </summary>
        /// <param name="randi">A random generált mező pozíciója az Y-tengelyen.</param>
        /// <param name="randj">A random generált mező pozíciója az X-tengelyen.</param>
        /// /// <param name="numi">A kattintott mező pozíciója az Y-tengelyen.</param>
        /// <param name="numj">A kattintott mező pozíciója az X-tengelyen.</param>
        /// <returns>Arra a mezőre kattintottunk-e, amit a random-generátor legenerált.</returns>
        private bool randomAdjacent(int randi, int randj, int numi, int numj)
        {
            return ((randi == numi && randj == numj) || (randi == numi - 1 && randj == numj - 1) || (randi == numi - 1 && randj == numj) ||
                (randi == numi - 1 && randj == numj + 1) || (randi == numi && randj == numj - 1) || (randi == numi && randj == numj + 1) ||
                (randi == numi + 1 && randj == numj + 1) || (randi == numi + 1 && randj == numj) || (randi == numi + 1 && randj == numj - 1));
        }

        #endregion

        #region Private event methods

        /// <summary>
        /// Játék elvesztéséhez tartozó esemény kiváltása.
        /// </summary>
        private void OnGameOverEvent()
        {
            GameOverEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Játék megnyeréséhez tartozó esemény kiváltása.
        /// </summary>
        private void OnGameWonEvent()
        {
            GameWonEvent?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
