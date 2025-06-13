https://forum.godotengine.org/t/how-do-i-enable-vsync-in-gdscript/1236/3

The link's code is in GDScript, but should not be a huge task to translate it.

Godot Projects separate some of the more technical elements, typically things in graphics settings, are editable in the Project Tab at the top of the editor. At run time, it seems these things can be changed by the DisplayServer class. I have not, and don't intend to for a while, change any of these settings, but I can absolutely do so, just some trial and error to figure out how to properly connect to it, and if there are multiple separate classes for other elemsnts in the Project Settings, aka how those things are grouped.