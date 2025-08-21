Godot has four types of collision objects and they all function differently. The following is an overview of them, notes taken from https://docs.godotengine.org/en/stable/tutorials/physics/physics_introduction.html

Area2D - detects and can emit a signal when a collision occurs. Seems to be most useful for handling AoE effects, like high/low gravity, but is probably not the right approach for something like an icy floor.
	I may want to use a custom subclass of this for detecting the bird passing through the the pipes and giving a point. Or perhaps just a line. Though in either case there will need to be some maintained data which ensure the player doesn't get a point every frame they collide with the line/area.


StaticBody2D - Objects which detect and may make calls about their collisions, but are not moved by the physics system and are therefore not moved by any collision. This seems useful for things like platforms and spikes.


RigidBody2D - a 2D physics object which is moved by applying forces to the object. This sounds highly appropriate for the Pipes, as they will be moving at a constant velocity leftward.


CharacterBody2D - a 2D physics object not handled by the physics engine, all movement and collision response must be handled by code. This currently seems rather appropriate for the Bird, as I want to control the motion of the bird pretty tightly and I will need to listen to the user for input. Which I seem to be unable to do at this time.