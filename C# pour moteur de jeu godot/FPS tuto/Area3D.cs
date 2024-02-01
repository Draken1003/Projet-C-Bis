using Godot;
using System;

public partial class Area3D : Godot.Area3D
{
    private Label label;

    public override void _Ready()
    {
        label = GetNode<Label>("Label"); // Remplacez "Label" par le nom réel de votre label
    }

    public void _on_body_entered(Node body)
    {
        if (body is player) // Vérifiez si le nœud qui entre est de type player alors
        {
            label.Text = "dans la zone";
            label.Show();
        }
    }

    public void _on_body_exited(Node body) 
    {
        if (body is player) // Vérifiez si le nœud qui sort est de type player alors
        {
            label.Hide(); //le message se cache 
        }
    }
}