using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeSim.Persistence
{
    public interface IPersistence
    {
        /// <summary>
        /// Fájl betöltése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <returns>A fájlból beolvasott adatok egy Stringeket tartalmazó listában.</returns>
        Task<List<String>> LoadGame(String path);

        /// <summary>
        /// Fájl mentése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="values">A fájlba írandó adatok.</param>
        Task SaveGame(String path, List<String> values);

        /// <summary>
        /// Fájlba való beillesztés. (az achievement rendszerhez, hogy ne kelljen mindig újra elmenteni az összes adatot, csak az éppen szükségeset)
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        /// <param name="value">A fájlba illesztendő adat.</param>
        Task AppendToFile(String path, int value);

        /// <summary>
        /// Achievementek betöltése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        Task<List<int>> LoadAchievements(String path);
    }
}
