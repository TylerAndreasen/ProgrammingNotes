# QuickGraph, a simple graph builder

I have, for a while, wanted a simple tool that allows me to be able to build good looking graphs quickly and easily.
There are tools online that allow the user to build certain kinds of graphs, including UML diagrams, which I would also like to implement.
That said, I think that building something like this will be complicated enough that I should start out with a smaller scope in mind, and expand or start from scratch when appropriate.
So what do I want for version 1?
I see two potential options:
1. I build something that allows me to build graphs akin to the state machines used as visual aids in classes with Professor [REDACTED]. These would be simple shapes, or even just all circles, with a few characters contained within to indicate the state ID. First drafts would need to allow vertices to be created, placed, picked-up and moved, and have connections made between them. I would also want to be able to undo actions. The last two desired features, as I realize, imply pretty significant development time to make viable. Drawing connections manually should probably be achieved by having a mouse tool for manipulating the vertices and another tool for edges, while undoing actions requires a stack of completed actions that are pushed on when an action is successfully compeleted, popped off when an action is undone (and placed in a separate stack), and repushed when the action is reapplied.


2. I build something that operates in a manner more similar to Twine, a tool designed to help creatives make text-based adventure games that run in a browser. The important functional difference with this option is that each node has a name, and a description, the latter only appearing if the user opens a menu for that vertex. After some thinking, this functionality is really just an extention, and this version would 1. have square name-desc. elements and 2. not prioritize splines for edges, though I have no idea how hard those would be to implement with or without using built in raylib tools (though I suspect there is a raylib spline implementation).

Given the above, there are still a huge number of things that complicate the design of either option, and the two options differ less than I originally though they would. I intend to eventually build a system that implements all of the above ideas, but I think I need to start a little smaller to keep myself sane during the design phase. So, I am going to cut back the design.

3. I build something simpler than 1. Key Features: Mouse Tools: {Manipulating Vertices (create, edit, move, delete), Manipulating Edges(create, edit, delete)}, Apperance: {Vertices: All vertices are circles with a maximum number of characers within, Edges: The shortest possible line between the outsides of the vertices being connected}, Graph Style: {What kind of graph am I implementing? for this to be useful, will want to be able to show directions between graphs, and implementing as undirected graph first feels like a poor fit. Then, do I implement weights on the edges. I think I do, but always assign them 1 as a magnitude. And if a graph as wieghts of all 1s, don't show the wieghts unless an override field is set.}

### **1. The Plan**

Unlike my Snake implementation (which I do want to build an AI to complete automatically), I will need to use OOP concepts and multiple files to build this project, easier now that I understand header files and vectors. Thinking about it, I really don't need to implement any of the sorts of concepts or test of graph completeness, connectedness, or such from Math+CS classes, as they really are not necessary for a visual aid, as these features of graphs can be seen pretty intuitively for small graphs and are not all that important for the sorts of graphs I intend to make.

## **2. The Design**

What, from a code perspective are the baseline required class to make this happen:

1. Vertex, Edge, Graph: These will keep track of the relevant data, and make all of the other operations of the program easier.
    1. Vertex - Objects are defined with a string field name/text, and an `vector<int>` for the center position of the circle and text on screen. The string must be betwen one and five characters in length, and when created will be automatically assigned the value of the character 'q' followed by the next index as tracked by the Graph object this vertex is associated with. I think that I will 1 index the vertex strings because I can.
    Edge - Objects will store references to two incident vertices, O and D for origin and destination, and an integer weight.
    Graph - Stores a vector of Vertex and Edge Objects (all Vertex and Edge objects should be associated with the graph, even if a Vertex does not have any incident Edges). The Graph object will then be responsible for managing Vertex and Edge relations (ie, if a vertex is removed check all Edges, and remove all Edges associated with the Vertex. I don't plan to let the Vertices know what Edges they are associated with, doesn't feel necessary.)
2. MouseManager: This class will be responsible for responding to user input, maintaining an internal state based on the current mouse tool, letting the Graph know that action is being taken. It occurs to me that the MouseManager class will need to let the graph know that, for example, a Vertex is being moved, I need to spend time on this.
    1. What are the implications? The MM object will need to call one of several methods on the Graph object it has a reference to, and this will depend on the internal state of the MM object, the side of the click, and what is under the mouse at the time. I have some ideas about how I might go about this:
        1. Each frame the MM calls on the Graph with the current mouse position to see if the mouse is over anything in the Graph, ideally this will also cause the item to be highlighted in some way on screen, returning a value to indicate nothing/vertex/edge. Vertices should be pretty straight forward, the Graph runs through all vertices in the vector, checking if the mouse position is within the radius of the center of each vertex. Edges, especially when I implement splines, will require more care to determine if the user is close enough to click on it. Whatever the case, a method call returns if or what type of object is below the mouse, this is then used to determine the get call for a reference to the object below the mouse that frame. These data are then used to ensure that any user input for the frame is valid (don't do anything if the user is clicking on nothing). Further, this style can be used to implement the UI buttons necessary for setting the mouse mode. Also, I am using raylib, I should probably spend sometime looking at what packages are within raylib and what tools might exist to make this process easier.


### **Useful Links**

https://www.raylib.com/examples.html    Input Box example
                                        Format Text
                                        




### **N. Other Functionality**
There are a whole host of other things I want to implement into a system like this:
1. Splines for giving controlled or automatic curves to edges to be more clear.
2. Vertices having an editable description box which allows the system to act more like Twine.
3. Object serialization to allow the user to save graphs to disc and read them back later just to reference or change the graph.
4. Changing the visualization of all Vertices or specific vertices. Either by selecting which shape to place or placing, selecting, and indicating a shape to change to.
5. With a Vertex selected, have the system automatically determine the closest (example) 5 vertices and allow the user to press the keys 1-5 or q-t to automatically create edges to those vertices.
6. UML Aesthetic: Implementing Special Vertex and Edge behaviors that create reasonable UML diagrams. This would entail focal points on the Name line and each line in the fields and methods sections. (Also selecting to be able to place two- or three section UML elements). Further, this would need to implement options for the 1:1, 1:N, and N:N relations between tables.
7. Undirected and Unwieghted modes for the visualization. All graphs will always be directed and weighted in the background.
8. The actual space that the Graph can take up is bigger than the screen is initially, allowing for zooming and panning within a larger space. Note, this does then require positions to be stored in refernce to the top corner of the entire space, which are then scaled accoring to the zoom level and panning position of the camera.
9. Highlighting the hovered object on screen.