using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LifeSim.Persistence
{
    /// <summary>
    /// LifeSim perzisztenciája szöveges fájlokkal.
    /// </summary>
    public class TextFilePersistence
    {
        /// <summary>
        /// Fájl betöltése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <returns>A fájlból beolvasott adatok egy Stringeket tartalmazó listában.</returns>
        public List<String> LoadGame(String path)
        {
            if (path == null) // ha az útvonal null, akkor kivételt dob
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path)) // megnyitja a fájlt
                {
                    String[] tmp = reader.ReadToEnd().Split(); // a fájlból szóközönként elválasztva beolvas minden adatot egy String tömbbe
                    List<String> values = new List<String>(tmp); // ezt belerakja egy listába

                    return values;
                }
            }
            catch // ha valamiért nem sikerül a fájl megnyitása, akkor kivételt dob
            {
                throw new DataException("Hiba történt a betöltés közben.");
            }
        }

        /// <summary>
        /// Fájl mentése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="values">A fájlba írandó adatok.</param>
        public void SaveGame(String path, List<String> values)
        {
            // ha az útvonal, vagy az írandó értékek null-t tartalmaznak, akkor kivételt dob
            if (path == null)
                throw new ArgumentNullException("path");
            if (values == null)
                throw new ArgumentNullException("values");

            try
            {
                using (StreamWriter writer = new StreamWriter(path)) // megnyitja a fájlt
                {
                    writer.Write(values.Aggregate((value1, value2) => value1 + " " + value2)); // beleírja a fájlba az összes adatot szóközzel elválasztva
                }
            }
            catch // ha valamiért nem sikerül a fájl megnyitása, akkor kivételt dob
            {
                throw new DataException("Hiba történt a mentés során.");
            }
        }

        /// <summary>
        /// Fájlba való beillesztés. (az achievement rendszerhez, hogy ne kelljen mindig újra elmenteni az összes adatot, csak az éppen szükségeset)
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="value">A fájlba illesztendő adat.</param>
        public void AppendToFile(String path, int value)
        {
            if (path == null) // ha az útvonal null, akkor kivételt dob
                throw new ArgumentNullException("path");

            try
            {
                if (File.Exists(path)) // ha már létezik a fájl, akkor egy szóközzel elválasztva az előző adattól beírja az újabbat
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.Write(" " + value.ToString());
                    }
                }
                else //különben csak az adatot írja be
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.Write(value.ToString());
                    }
                }
            }
            catch // ha valamiért nem sikerül a fájlba írás, akkor kivételt dob
            {
                throw new DataException("Hiba történt a fájlba írás során.");
            }
        }

        /// <summary>
        /// Achievementek betöltése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        public List<int> LoadAchievements(String path)
        {
            if (path == null) // ha az útvonal null, akkor kivételt dob
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path)) // megnyitja a fájlt
                {
                    String[] values = reader.ReadToEnd().Split(); // a fájlból szóközönként elválasztva beolvas minden adatot egy String tömbbe

                    return values.Select(value => int.Parse(value)).ToList(); //a beolvasott adatokat int-té parse-olja, és int-ek listájába rakja, amit vissza is térít.
                }
            }
            catch
            {
                throw new DataException("Hiba történt a betöltés közben.");
            }
        }
    }
}
