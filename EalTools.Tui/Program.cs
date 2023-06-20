using EalTools.Tui;
using Terminal.Gui;

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
