using Godot;
using System;

public partial class hero_bar: Control
{
    public AnimationPlayer animOpen_Close;
    public Button open;
    bool heroBarOpen = false;
    public override void _Ready()
    {
        animOpen_Close = GetNode<AnimationPlayer>("Open_Close");
        open = GetNode<Button>("open");
    }
    private void _on_open_pressed()
    {
        if (heroBarOpen == false)
        {
            animOpen_Close.Play("open");
            open.Text = "close";
            heroBarOpen = !heroBarOpen;
        }
        else
        {
            animOpen_Close.Play("close");
            open.Text = "open";
            heroBarOpen = !heroBarOpen;
        }
        
    }

}
