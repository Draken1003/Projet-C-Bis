extends Node2D


func _on_button_pressed():
	Global.load_scene(self, "world")
	
