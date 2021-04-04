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
    }
}
