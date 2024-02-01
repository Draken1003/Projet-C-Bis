using Godot;
using System;

public partial class Money : Control
{
    public float argent = 100f; //argent de base
    public Label money;

    public override void _Ready()
    {
        money = GetNode<Label>("money");   
    }

    public override void _Process(double delta)
    {
        money.Text = argent.ToString(); //converti un float en string pour changer le texte de money
    }
}
