# Planning for Snake

My next goal is to create snake in raylib, after the fairly straight forward process of creating pong, I want to try my hand at making Snake on my own.
(In theory, I can later add on various automatic players (simple algorithms, complex algorithms, and or machine learning) ).

The Pong tutorial emphasized the design pattern of the Definitions (all of the data required for the game) and the Game Loop (the steps that must happen for each cycle of the game engine). Note:: I am unaware (though suspect there is) of any way to decouple the game loop from the frame updates. For more complex games, this becomes more of a problem, but is likely a strength for games like snake.

Definitions
    int     - side : for visual square size
    Size of Grid and Window
    bool    - snakeDiedThisFrame
    Cell    - int x,y
    Grid    - [][]Cell, []Cell getNotInSnake(Snake)
    Snake   - `vector<Cell>`, int growCounter, int lastMoveDir, enum MOVE_DIRS {UP, RIGHT, DOWN, LEFT}
    Apple   - Cell


    

Game Loop

    Update Snake
    if gameShouldEnd -> do
    Update Apple
    Draw Snake
    Draw Apple


### **Thoughts**

I realize that, while not a good habit, placing all of the code for the game into a single file (avoiding headers) will make development simpler at the cost of more scrolling, which I do actually want to try.
I should also write out a list of all steps I should take in order before I implement anything. I will not be implementing anything (almost certainly) on the evening this is being written as I want to take care to consider the steps I am planning, and may not even feel confident that I have done a viable plan before signing off.

IMPORTANT:: Use the native C++ vector<> class. It will be incredibly helpful, as it handles much of the list functionality that I need.

### **Steps**
1. Confirm Raylib is accesible in the new solution. (Should be achieveable by including it, `#include "raylib.h"`) 
2. Determine the desired size of the grid and the size of cells within the grid to determine screen size, implement as constants. 
3. Define Cell class, draw() 
4. Define Snake class (will require draw and update methods).
    The Snake::Update method will
        1. Accept a param that says whether it ate something last frame, and add the value to the growCounter.   
        1. Read input from the keyboard. If any, set move dir to new value.
        2. Apply current move (account for moving the snake and growing if the grow counter isn't 0).
        3. Determine if the Snakes's head tried to move out of bounds or move into the tail.
        4. Return a Vector2 that expresses the head of the snake.
5. Define Apple class. When the position of the head of the snake (returned from update) matches the current apple position, choose a random position from the grid that is not within the snake.
6. Implement restarting the game on death

### **Iteration 1**
After completing the Steps I laid out, and some small tweaks to make Resetting the game easier, I have some thoughts about the feel of the game.
First, the input does not feel great. I cannot quite put into words the feeling, but I do take issue with it.
At times it feels like inputs get missed, and especially rapid switch backs don't happen as desired.
I think there are a few ways to handle this, beyond simply calling it a feature.
1. Create some input queue, which stores multiple inputs so that they can be applied on future update cycles.
    1. I don't love this. While the snake moves at what I believe to be a reasonable pace, saving inputs to be applied in a grid based game, where only one input can be applied in a turn, I suspect would feel very strange, as it may be half a second between when you accidentally pressed a button, and the game visually registers that you pressed it. Though maybe this would feel better.
2. Building on the input queue idea, each frame, read in ALL user input (filtering to just the arrow keys) and store the order in which they are pressed. Once an Update to the position of the snake occurs, read the last element of the list. If the last element is a legal movement for the 
    1. I originally wrote the above with the idea that the last element would be read as the direction to try to move in first. It occurs to me that this is not condusive to how I have been playing. When I try to space fill with the tail of the snake, I will quickly input with the two directions the snake will need to travel, and only sometimes get the result I want. This has made me consider an alternative I had given no thought, what if the snake is too fast? I had previously assumed that updating the snake four times a second would be the slowest the game should possibly be, but this is not necessarily the case, and I am curious how the game would feel with a slower update rate and possibly a display that shows the frames until the next update. Lets start with the frame counter.
    2. I slowed the game engine down to 3 updates per second (down from 4 per second). I like the input a little better, but I still don't love it. The lower speed makes the game feel almost sluggish, I can try 2 updates per second, but I don't think going further will help. I want to investigate what having an input queue might feel like. Idea being that the player is allowed to input direction changes too fast, and they will still be respected. So the update cycle is listening o

TODO:: Reimplement the 180 detection with a switch.

### **IDEAS**

1. Implement a version that makes the head of the snake swap to the opposite end whenever an apple is eaten (this may end in unavoidable losses in every game). This feels like a task for machine learning though.
2. Apply algorithmic or machine learning solutions to play the game.
