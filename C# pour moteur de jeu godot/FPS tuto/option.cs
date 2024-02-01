using Godot;
using System;

public partial class option : Control
{
    [Export] private menu _menu;
    public override void _Ready()
    {
        _menu.Hide();
    }
    private void _on_video_pressed()
    {

    }

    private void _on_audio_pressed()
    {

    }

    private void _on_back_pressed()
    {
        
    }
}
