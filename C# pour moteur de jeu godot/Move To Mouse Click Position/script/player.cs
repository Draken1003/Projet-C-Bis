using System.Security.Cryptography.X509Certificates;
using Godot;


public partial class player : Godot.CharacterBody2D
{
    [Export] private int speed = 300;
    public Vector2 velocity = Vector2.Zero; 
    public Vector2 click_position = Vector2.Zero;

    public override void _Ready()
    {
        click_position = new Vector2(Position.X,Position.Y);
    }

    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionJustPressed("left_click"))
        {
            click_position = GetGlobalMousePosition();  
        }

        Vector2 target_position = (click_position - Position).Normalized();
        GD.Print("position target", target_position);
        GD.Print("position souris", click_position);
        if (Position.DistanceTo(click_position) > 3)
        {
            Velocity = target_position * speed;
            LookAt(click_position);
            MoveAndSlide();
        }
    } 
}
