using Godot;
using System;
using System.Runtime.ExceptionServices;

public partial class menu : Control
{
    public VBoxContainer Menu;
    public Control Option;
    public Control Video;
    public Control Audio;
    

    public override void _Ready()
    {
        Menu = GetNode<VBoxContainer>("Menu");
        Option = GetNode<Control>("Option");
        Video = GetNode<Control>("Video");
        Audio = GetNode<Control>("Audio");
    }

    private void _on_option_pressed()
    {
        Option.Show();
        Menu.Hide();  
    }
    private void _on_quitter_pressed()
    {
        GetTree().Quit(); 
    }

    private void _on_video_pressed()
    {
        Video.Show();
        Option.Hide();
    }

    private void _on_audio_pressed()
    {
        Audio.Show();
        Option.Hide();
    }

    private void _on_back_from_option_pressed()
    {
        Option.Hide();
        Menu.Show();    
    }

    private void _on_full_screen_toggled(bool ButtonPressed)
    {
        
    }

    private void _on_border_less_toggled(bool ButtonPressed)
    {
        
    }

    private void _on_back_from_video_pressed()
    {
        Option.Show();
        Video.Hide();
    } 
}
