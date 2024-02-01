extends Node


const GAME_SCENES = {
	"world": "res://scene/world.tscn"
}

var loading_screen = preload("res://scene/loading_screen.tscn")






func load_scene(current_scene, next_scene):
	
	# Create a new loading screen instance
	var loading_screen_instance = loading_screen.instantiate()
	get_tree().get_root().call_deferred("add_child", loading_screen_instance)
	
	# Finds the path to the scene file . (needs to fletch from GAME_SCENES if applicable)
	var load_path : String
	if GAME_SCENES.has(next_scene):
		load_path = GAME_SCENES[next_scene]
	else:
		load_path = next_scene
	
	var loader_next_scene
	if ResourceLoader.exists(load_path):
		loader_next_scene = ResourceLoader.load_threaded_request(load_path)
	
	if loader_next_scene == null:
		print("error: Attempting to load non-existent file!")
		return 
		
	await loading_screen_instance.safe_to_load
	current_scene.queue_free()
	
	
	
	
	while true:
		var load_progress = []
		var load_status = ResourceLoader.load_threaded_get_status(load_path, load_progress)
		
		match load_status:
			0: #TREAD_LOAD_INVALID_RESOURCE
				print("error: Cannot load, resource is invalid.")
				return
			1: # TREAD_LOAD_IN_PROGRESS
				loading_screen_instance.get_node("Control/ProgressBar").value = load_progress[0]
			2: #TREAD_LOAD_FAILED
				print("error: Loading failed!")
				return
			3: #TREAD_LOAD_LOADED
				var next_scene_instance = ResourceLoader.load_threaded_get(load_path).instantiate()
				get_tree().get_root().call_deferred("add_child", next_scene_instance)
				
				loading_screen_instance.fade_out_loading_screen()
				return 
