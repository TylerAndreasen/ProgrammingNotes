# TowerDefense Plan

I am in the very earliest stages of building a tower defense game using raylib, and as I have learned, writing out an explicit and detailed plan is important to the project going smoothly and allowing me to come back to it after time away.

Major Conciderations:

- I know that I want to ensure that massive amounts of work is not required to replace basic colors with sprite rendering, though beyond Object Oriented Class implementation files, I am unsure how I need to change the design from a very straight-forward implementation.
- For a cell in the style that I am intending to use it, do I include explicit position data? Answer yes, I will need to use the distance between the cell and the end point to determine the heuristic for the enemy AI pathfinding. I could store these as an multi-dimensional array or vector, but I think it will be simpler to implement and faster to run without the impled overhead.
- I know that there is a lot of ways I can go about structuring the rest of this data and functionality.
    - One direction I can go is to keep everything as open as possible; build a vector of which every relevant component (pathfinding, player interaction, graphics manager) checks against until relevant data is found and acts on the result. I think this is quite a poor fit in the short and long runs, as there will need to be a lot of logic required to search through the list and find what is necessary, which really slows the program down if strings are used to identify properties.
    - Another direction is that there is a field in the cell class (an int acting as a boolean or otherwise) for every trait that the cell could have, which is also somewhat ineffecient.
    - The direction I plan on taking is a middle ground; define in a base cell class containing as little as is necessary to define a cell that can have some pathfinding AI use: position, references to adjascent cells, and a simple flag which indicates if the cell is accesible to pathfinding agents (note: in Robo Defense Free, this would be equivalent to all towers blocking pathing for ground troops, but none that block planes) and anything to do with graphics is placed in a subclass (implementing things like basic colors versus image based sprites versus compiled shapes).
        - I need to do some reading on how object oriented principles work in C++, as I have seen some disagreement about how to implement the equivalent of Java interfaces.
- I need to spend sometime with how to handle blocking the placing of a tower on a cell when a player tries to cut off all access to the exit. I do think the logic should be outside of the basic cell class, but I am unsure of how I want to implement it. Given that this feature is so foundational to the concept of a tower defense game, perhaps there should be logic in the base cell class to support this. The complication being that some but not all of the cells in the current optimal path at any time can be allowed to be filled, while others can. And of course the entry and exit cells must always be accessible to a pathfinding agent. 
- ?? How and where to track endpoints of the graph for pathfinding purposes?
- ?? How to handle towers of different types and functionalities? (Normal towers, pressure plates, MOAR)
- Others as I come up with them.

Issues:
- Vector of References: In C++, it is not possible (maybe without some C++ version), to create a vector of references to objects, a vector must contain the originals or copies. This led me to discover that I could use an class called a reference_wrapper to get the benefits of referencing usable within a vector.
- Attempt at reference_wrapper: After a couple of hours of fighting with implementing reference_wrapper, I could not figure out why exactly there was no available constructor for the `reference_wrapper<cell>`, including interfacing with ChatGPT, which tried to make the same point, but did not get the information across. I am led to believe (though I lack suffecient evidence to demonstrate this) that attempting to use the reference_wrapper in this way is a no-go. Namely, that you cannot create a vector of reference_wrapper objects as a field memeber of the same type: I cannot seem to store references to other cell objects in a cell object because there must always be a cell created to be placed into the vector of reference_wrapper objects. Again, I do not have suffecient evidence to convince myself of this fully, but it would be my best guess.  

Classes
```c++
cell
    private
        Fields
            int x, y;
            cell& n, e, s, w; //These represent the cells adjacent to this cell in the directions (n)orth, east, south, and west.
            int access; // 0 - inaccessible, !0 - accessible
            int endpoint; //Flag for endpoint status
            int interactable; //Flag used to stop player placing a tower on this cell
        methods
    public methods
        cell(int x, int y, int access); // Assigns implied fields and leaves all adjascent cell references null
        cell(int x, int y, int access, cell&, cell&, cell&, cell&); // Assigns implied fields, cells are in the order north, east, south, and west
        int pushAdjs(cell&, cell&, cell&, cell&);

        int pushAdj(cell&, int index);

        int getX();
        int getY();

        void setAccess();
        int getAccess();


colorcell extends cell
    private
        Fields
            int rendererColorIndex;

enemyAIPath
    private
        variables
            cell& start, end;
            vector<cell&> currentPath;
    public methods
        void setStart(cell&);
        void setEnd(cell&);
        void recalculatePath();
        int currentPathLength();
        vector<cell&> getCurrentPath();
```