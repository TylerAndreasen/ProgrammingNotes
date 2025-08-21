The editor is laid out similarly to Unity from what I read.
There is an built in file explorer, so the (local?) source files for things used by the game can be located on disk easily.
There is a built in code editor, with ability to open a description of a class by hovering+Ctrl, just use VS Code.

**Note On Scenes and Nodes:
	While working on Flappy Bird, I was absolutely baffled as to why I could not change the type of the Scanner Node inside the Pipe Obstacle Scene. The option to change the type didn't appear and this had me dumbfounded. The issue was rather simple, and pointed me towards a pull request I might make in the future. The Scanner Node was not a Node, but an instantiated Scene. Sensibly this Scene instantiation means that I cannot change the type of the Scanner from that part of the menu.
	Part 2: I quickly realized that when I went to change the type of the root node of the Scanner scene that I did not even need to change its type, as the script (the origin of this problem) I was trying to attach to the Scanner scene (of type Node2D) actually needed to be attached to the Area2D child of the root of the Scanner Scene.

