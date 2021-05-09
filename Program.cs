using System;
using System.Windows.Forms;
using LifeSim.LSView;

namespace LifeSim
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameStart gameStart = new GameStart();
            gameStart.Show();
            Application.Run();
        }
    }
}
