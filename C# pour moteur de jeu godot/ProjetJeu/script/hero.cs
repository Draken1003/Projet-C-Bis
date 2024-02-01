using Godot;
using System;

public partial class hero : Node2D
{
    public float attack = 2f;
    public float nb_level = 0;
    public Label level;
    public Label nb_attack; 

    public override void _Ready()
    {
        level = GetNode<Label>("Panel/VBoxContainer/Lvl/Level");
        nb_attack = GetNode<Label>("Panel/VBoxContainer/Atk2/Atk");
    }

    public override void _Process(double delta)
    {

    }
}
