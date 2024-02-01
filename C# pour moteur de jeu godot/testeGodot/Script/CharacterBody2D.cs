using Godot;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public const float Speed = 300.0f;
	private Vector2 _movementInput = Vector2.Zero;
	
	public void MovementPerformed(Vector2 input)
	{
		_movementInput = input.Normalized();
	}

	public void Stop()
	{
		_movementInput = Vector2.Zero;
	}

    public override void _PhysicsProcess(double delta)
    {
        Velocity = _movementInput * Speed;
		MoveAndSlide();
    }
		
}

