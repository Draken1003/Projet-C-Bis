using Godot;
using System;

public partial class CharacterAnimator : AnimationPlayer
{
	public const string ENEMY_ANIM = "EnemyAnim";
	public override void _Ready()
	{
		base._Ready();

		CurrentAnimation = ENEMY_ANIM;
	}

}