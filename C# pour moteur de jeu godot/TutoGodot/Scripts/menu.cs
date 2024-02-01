using Godot;
using System;

public partial class menu : Control
{
	private void _on_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/TestScene.tscn");
	}

	private void _on_option_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/menu_option.tscn");
	}

	private void _on_back_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
	}

	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}

	private void _on_volume_pressed()
	{
		//GetTree().();
	}
}
