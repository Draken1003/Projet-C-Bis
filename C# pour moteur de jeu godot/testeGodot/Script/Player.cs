using Godot;

public partial class Player : Node
{
	[Export] private PlayerInput _input = null;

	[Export] private CharacterBody2D _motor = null;
	// Called when the node enters the scene tree for the first time.

	public override void _Process(double delta)
	{
		_motor.MovementPerformed(_input.MovementInput);
	}
}
