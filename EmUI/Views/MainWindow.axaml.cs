using System.Drawing;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace EmUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        VideoPlayer.Loaded += OnPlayerLoaded;
        VideoPlayer.MediaPlayer.AspectRatio = null;
        VideoPlayer.MediaPlayer.Scale = 0;
        VideoPlayer.SizeChanged += (sender, args) =>
            VideoPlayer.MediaPlayer.CropGeometry = $"{Width}:{Height}";
    }

    private void OnPlayerLoaded(object? sender, RoutedEventArgs e)
    {
        if(Design.IsDesignMode)
            return;
        
        VideoPlayer.MediaPlayer.Volume = 0;
        VideoPlayer.MediaPlayer.MediaChanged +=
            (o, args) => VideoPlayer.MediaPlayer.Media!.AddOption(":input-repeat=65535");
        VideoPlayer.MediaPlayer.Media!.AddOption(":input-repeat=65535");
        VideoPlayer.MediaPlayer.Play();
        VideoPlayer.Loaded -= OnPlayerLoaded;
    }
}