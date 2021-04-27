using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeSim.Model
{
    public class LicenseQuestionsModel
    {
        #region Question-answer constants

        private readonly Dictionary<String, int> questionsAnswers = new Dictionary<String, int>
        {
            { "Mi a leálló sáv? " + Environment.NewLine + "a) Az útnak az úttesttel azonos szintben lévő, attól útburkolati jellel elválasztott, útburkolattal ellátott része." +
                Environment.NewLine + "b) Az útnak az úttest mellett lévő, útburkolattal el nem látott része." + Environment.NewLine + "c) Az úttest szélén, az autók szabályos" +
                " parkolására kialakított forgalmi sáv.", 0 },
            { "Adhat-e hangjelzést kikerülési szándékának jelzésére?" + Environment.NewLine + "a) Igen." + Environment.NewLine + "b) Nem." + Environment.NewLine + "c) Csak lakott" +
                "területen kívül.", 1  },
            { "A három külön úttesttel rendelkező út középső úttestjén " + Environment.NewLine + "a) Megállni tilos." + Environment.NewLine + "b) Megállhat, de nem várakozhat." +
                Environment.NewLine + "c) Megállni, várakozni egyaránt szabad.", 1 },
            { "Közlekedhet-e főútvonal melletti kerékpárúton 12 éven aluli gyermek?" + Environment.NewLine + "a) Igen." + Environment.NewLine + "b) Igen, de csak kísérővel." +
                Environment.NewLine + "c) Nem.", 0 },
            { "Segédmotoros kerékpáron szabad-e utast szállítani? " + Environment.NewLine + "a) Igen." + Environment.NewLine + "b) Nem." + Environment.NewLine + "c) Csak ha a vezető" +
                " elmúlt 18 éves, és utasa 10 éven aluli.", 1 },
            { "Főútvonalon közlekedik. Kényszerítheti-e Önt egy másik jármű fékezésre, vagy irányváltoztatásra?" + Environment.NewLine + "a) Igen, mert számos olyan helyzet adódhat," +
                " amelyet csak a partner közreműködésével lehet biztonságosan megoldani." + Environment.NewLine + "b) Csak balesetveszély esetén, a baleset megelőzése érdekében." +
                Environment.NewLine + "c) Nem.", 0 },
            { "Mekkora a személygépkocsik megengedett legnagyobb sebessége?" + Environment.NewLine + "a) Lakott területen 50 km/h, autópályán 130 km/h, autóúton 110 km/h, egyéb úton " +
                "90 km/h." + Environment.NewLine + "b) Lakott területen 50 km/h, autópályán és autóúton 100 km/h, egyéb úton 80 km/h." + Environment.NewLine + "c) Lakott területen " +
                "50 km/h, autópályán 120 km/h, lakott területen kívül és egyéb úton 90 km/h.", 0 },
            { "Várakozhat-e lakó-pihenő övezetben olyan úton, ahol van járda?" + Environment.NewLine + "a) Igen, de csak a kijelölt várakozóhelyen." + Environment.NewLine +
                "b) Nem. Csak megállni szabad, várakozni mindenütt tilos." + Environment.NewLine + "c) Igen.", 2 },
            { "Hol haladhat személygépkocsival 90 km/h-nál nagyobb sebességgel?" + Environment.NewLine + "a) Lakott területen kívül bárhol." + Environment.NewLine +
                "b) Csak autópályán és autóúton, ha nincs kitéve 90 km/h-t és annál kisebb sebességet megjelölő \"Sebességkorlátozás\" jelzőtábla." + Environment.NewLine + "c) " +
                "Autópályán és autóúton (ha nincs kitéve 90 km/h-t és annál kisebb sebességet megjelölő \"Sebességkorlátozás\" jelzőtábla), továbbá minden egyéb olyan helyen, ahol " +
                "a \"Sebességkorlátozás\" jelzőtábla 90 km/h-nál nagyobb sebességet jelez.", 2 },
            { "Áthaladhat-e gyalogosként az autóút úttestjén?" + Environment.NewLine + "a) Igen, bárhol." + Environment.NewLine + "b) Csak útkereszteződésben." 
                + Environment.NewLine + "c) Nem.", 1 },
            { "Elromlott járművet vontat. Milyen hosszú lehet a vonórúd, illetve a vontatókötél?" + Environment.NewLine + "a) Legfeljebb 4 m hosszú." + Environment.NewLine +
                "b) Legfeljebb olyan hosszú, mint a vontatott jármű." + Environment.NewLine + "c) Legfeljebb olyan hosszú, mint a vonó jármű.", 1 },
            { "Legalább mekkora sebességkülönbség szükséges az előző és az előzendő gépjárművek között, hogy az előzési út ne legyen túl hosszú?" + Environment.NewLine +
                "a) Kb. 5...6 km/h." + Environment.NewLine + "b) Kb. 10...15 km/h." + Environment.NewLine + "c) Kb. 15...20 km/h.", 2 },
            { "Felnőtt gyalogosok zárt csoportja az út mely részén közlekedhet?" + Environment.NewLine + "a) Mindig az úttest menetirány szerinti jobb szélén." +
                Environment.NewLine + "b) A járdán, a leállósávon, az útpadkán, illetve a kerékpárúton. Ha pedig ez nincs (vagy nem járható), az úttest menetirány szerinti jobb" +
                "szélén." + Environment.NewLine + "c) Lakott területen belül lehetőleg, lakott területen kívül pedig mindig az úttest menetirány szerinti bal szélén.", 0 }
        };

        #endregion

        #region Fields

        private Random rnd; //véletlenszám-generátor változója

        #endregion

        #region Properties

        /// <summary>
        /// Kérdés tulajdonság.
        /// </summary>
        public String Question { get; private set; }

        /// <summary>
        /// Válasz tulajdonság.
        /// </summary>
        public int Answer { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Jogosítvány kérdéssor példányosítása.
        /// </summary>
        public LicenseQuestionsModel()
        {
            rnd = new Random();
            int randomIndex = rnd.Next(0, questionsAnswers.Count());
            Question = questionsAnswers.ElementAt(randomIndex).Key;
            Answer = questionsAnswers.ElementAt(randomIndex).Value;
        }

        #endregion

    }
}
