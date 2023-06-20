using EalTools.Riff;

using Terminal.Gui;
using Terminal.Gui.Trees;

namespace EalTools.Tui;

public class EalFileView : Window
{
    private readonly MenuBar _menuBar;
    private readonly TreeView<IChunk> _treeView;
    private readonly FrameView _detailsFrame;
    private readonly ChunkDetailsView _chunkDetailsView;

    private EalFileView()
    {
        // Room for menu
        X = 0;
        Y = 1;
        Width = Dim.Fill();
        Height = Dim.Fill(1);
        ColorScheme = Colors.TopLevel;

        _menuBar = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Open", "", () => Open()),
                // new MenuItem ("_Export", "", () => Export()),
                new MenuItem ("_Close", "", Close),
                null!,
                new MenuItem ("_Quit", "", Quit),
            })
        });

        _treeView = new TreeView<IChunk>()
        {
            X = 0,
            Y = 0,
            Width = 40,
            Height = Dim.Fill(),
            TreeBuilder = new DelegateTreeBuilder<IChunk>(
                (o) => o is ListChunk c ? c.SubChunks : Enumerable.Empty<IChunk>())
        };

        _detailsFrame = new FrameView()
        {
            Title = "Details",
            X = Pos.Right(_treeView),
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        _chunkDetailsView = new ChunkDetailsView()
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        _treeView.SelectionChanged += TreeView_SelectionChanged;

        Application.Top.Add(_menuBar, this);
        Add(_treeView);
        Add(_detailsFrame);
        _detailsFrame.Add(_chunkDetailsView);

        _detailsFrame.Enabled = false;

        _treeView.SetFocus();
    }

    public static EalFileView Init()
    {
        return new EalFileView();
    }

    private void LoadEalFile(string filePath)
    {
        var ealFile = new EalFile(filePath);
        if (ealFile.Initialize())
        {
            Title = Path.GetFileName(filePath);
            _detailsFrame.Enabled = true;
            _treeView.ClearObjects();
            _treeView.AddObject(ealFile.RootChunk);
            _treeView.GoToFirst();
            _treeView.Expand();
        }
    }

    private void UnloadEalFile()
    {
        Title = string.Empty;
        _treeView.ClearObjects();
        _detailsFrame.Enabled = false;
    }

    private void TreeView_SelectionChanged(object? sender, SelectionChangedEventArgs<IChunk> e)
    {
        ShowChunkDetails(e.NewValue);
    }

    private void ShowChunkDetails(IChunk chunk)
    {
        _detailsFrame.Title = chunk?.ToString() ?? "Details";
        _chunkDetailsView.Chunk = chunk ?? new UnknownChunk();
    }

    private void Open()
    {
        var allowedTypes = new List<string>() { ".eal", ".*" };
        var dialog = new OpenDialog("Open", "Choose the file to open.", allowedTypes)
        {
            AllowsMultipleSelection = false
        };
        Application.Run(dialog);

        if (!dialog.Canceled && dialog.FilePaths.Count > 0)
        {
            UnloadEalFile();
            LoadEalFile(dialog.FilePaths[0]);
        }
    }

    private void Close()
    {
        UnloadEalFile();
    }

    private void Quit()
    {
        // if (!CanCloseFile ()) {
        //     return;
        // }

        Application.RequestStop();
    }
}
