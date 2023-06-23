using Terminal.Gui;

namespace EalTools.Tui
{
    class Program
    {
        static void Main()
        {
            Application.Init();

            try
            {
                EalFileView.Init();
                Application.Run();
            }
            finally
            {
                Application.Shutdown();
            }
        }
    }
}
