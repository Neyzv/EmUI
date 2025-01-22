using System;
using System.IO;
using System.Linq;
using ReactiveUI;

namespace EmUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
    
    private string? _videoPath;
    public string? VideoPath
    {
        get => _videoPath;
        set => this.RaiseAndSetIfChanged(ref _videoPath, value);
    }

    public MainWindowViewModel()
    {
        LoadRandomVideo();
    }
    
    private void LoadRandomVideo()
    {
        var videoFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Videos", "Home"), "*.mp4")
            .ToArray();

        VideoPath = videoFiles.Length != 0 ? videoFiles[Random.Shared.Next(videoFiles.Length)] : null;
        
    }
}