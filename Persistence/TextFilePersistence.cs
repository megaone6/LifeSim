using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LifeSim.Persistence
{
    public class TextFilePersistence
    {
        public List<String> LoadGame(String path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String[] tmp = reader.ReadToEnd().Split();
                    List<String> values = new List<String>(tmp);

                    return values;
                }
            }
            catch
            {
                throw new DataException("Hiba történt a betöltés közben.");
            }
        }
        public void SaveGame(String path, List<String> values)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (values == null)
                throw new ArgumentNullException("values");

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(values.Aggregate((value1, value2) => value1 + " " + value2));
                }
            }
            catch
            {
                throw new DataException("Hiba történt a mentés során.");
            }
        }

        public void AppendToFile(String path, int value)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            try
            {
                if (File.Exists(path))
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.Write(" " + value.ToString());
                    }
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(path))
                    {
                        writer.Write(value.ToString());
                    }
                }
            }
            catch
            {
                throw new DataException("Hiba történt a fájlba írás során.");
            }
        }
        public List<int> LoadAchievements(String path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String[] values = reader.ReadToEnd().Split();

                    return values.Select(value => int.Parse(value)).ToList();
                }
            }
            catch
            {
                throw new DataException("Hiba történt a betöltés közben.");
            }
        }
    }
}
