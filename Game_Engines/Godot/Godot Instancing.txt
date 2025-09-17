Godot relies on Instancing, creating objects in game that are copies of assets, similar to Unity's prefab system.
This is accomplished by right-clicking the "res://" level of the FileSystem tab in Godot, selecting New > Scene and then creating the scene as desired.
In my case, I will want to create a scene that creates the player, one that creates a single pipe, and one that creates double pipes with the detector.
I don't know how I will approach UI or user input yet, but I will figure that out later. Hey, there is a UI Scene, use that one!

Notes: I am stuck on what I need to do to make a yellow circle for the bird. I tried just a png and got the inevitable white bounding box.
I may be able to use something in Godot itself to make a basic circle, but will need to look at the instance practice project to really get a feel for it.
I don't know if the same problem will apply to the pipes, though trying to make them pretty probably will cause similar weirdness.

---
extends Node

@export var Ball: PackedScene

func _input(event):
	if event.is_action_pressed("click"):
		var new_ball = Ball.instantiate()
		new_ball.position = get_viewport().get_mouse_position()
		add_child(new_ball)
---
The above code is taken from the Bouncing Ball example provided by Godot. I am
unsure if there is an intended way to read UI from methods other than _input(event), but I believe that I will need to redesign my input to try to look like this.