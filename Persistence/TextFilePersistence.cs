using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<List<String>> LoadGame(String path)
        {
            if (path == null) // ha az útvonal null, akkor kivételt dob
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path)) // megnyitja a fájlt
                {
                    int count = Int32.Parse(await reader.ReadLineAsync());
                    List<String> values = new List<String>();
                    for (int i = 0; i < count; i++)
                    {
                        values.Add(await reader.ReadLineAsync());
                    }

                    return values;
                }
            }
            catch // ha valamiért nem sikerül a fájl megnyitása, akkor kivételt dob
            {
                throw new DataException();
            }
        }

        /// <summary>
        /// Fájl mentése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="values">A fájlba írandó adatok.</param>
        public async Task SaveGame(String path, List<String> values)
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
                    foreach (String word in values)
                    {
                        await writer.WriteLineAsync(word);
                    }
                }
            }
            catch // ha valamiért nem sikerül a fájl megnyitása, akkor kivételt dob
            {
                throw new DataException();
            }
        }

        /// <summary>
        /// Fájlba való beillesztés. (az achievement rendszerhez, hogy ne kelljen mindig újra elmenteni az összes adatot, csak az éppen szükségeset)
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="value">A fájlba illesztendő adat.</param>
        public async Task AppendToFile(String path, int value)
        {
            if (path == null) // ha az útvonal null, akkor kivételt dob
                throw new ArgumentNullException("path");

            try
            {
                if (File.Exists(path)) // ha már létezik a fájl, akkor egy szóközzel elválasztva az előző adattól beírja az újabbat
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        await writer.WriteAsync(" " + value.ToString());
                    }
                }
                else //különben csak az adatot írja be
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        await writer.WriteAsync(value.ToString());
                    }
                }
            }
            catch // ha valamiért nem sikerül a fájlba írás, akkor kivételt dob
            {
                throw new DataException();
            }
        }

        /// <summary>
        /// Achievementek betöltése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        public async Task<List<int>> LoadAchievements(String path)
        {
            if (path == null) // ha az útvonal null, akkor kivételt dob
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path)) // megnyitja a fájlt
                {
                    var valuesTmp = await reader.ReadToEndAsync(); // a fájlból beolvassuk az összes adatot
                    String[] values = valuesTmp.Split(); // ezeket szóközönként elválasztjuk, majd az így kapott elemeket berakjuk egy String tömbbe
                    return values.Select(value => int.Parse(value)).ToList(); // a beolvasott adatokat int-té parse-olja, és int-ek listájába rakja, amit vissza is térít.
                }
            }
            catch
            {
                throw new DataException();
            }
        }
    }
}
