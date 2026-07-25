# **Godot UI**

There ought to be many more things outlined in this UI document than I will write in my first draft, though I will return to this overtime.

## **Table of Contents**

1. Basics of UI in Godot
2. Containers and Scenes


### **1. Basics of UI in Godot**

Elements intended for use in games in Godot typically descend from the `Node2D` or `Node3D` classes. Elements intended for the UI of a game or software built in Godot typically descend from the `Control` class. Though there are various other nodes that can be utilized for game logic in particular, and I imagine are typically invisible.

The UI nodes, which are of the focus of this document, come in many varieties and their names are generally descriptive of their intended use. A great deal of these nodes function to manipulate the visual relationships between elements in the UI being built. Some align their child nodes vertically or horizontally, some act as padding between more meaningful sibling nodes, and others create browser-like tabs to separate a huge amount of information to be switched between in a section of the UI.

But the most important node to descend from the base `Control` node is the `PanelContainer`. As best as I understand at this time, creating any UI of any meaninful complexity will require panels to be added to give UI elements sway amoung their siblings. Though this may be the result of missing a field to change when using one scene as a packaged UI element in another scene. This was the first way I found to ensure that two buttons would appear with a small, though not specified, gap between them inside of an `HBoxContainer`.

### **2. Containers and Scenes**