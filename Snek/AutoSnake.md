# AutoSnake

I would like to, in the style of Code Bullet, create one or more automatic solvers for my snake game.
Unfortunately, in my copying code from a single file to multiple files with headers in a separate Solution, I have some how broken the mechanism by which the snake grows. I am really unsure of how to diagnose this, as it seems that I may fundemantally misunderstand how C++ handles fields.
The implementation really seems like there should be 0 issues, the Snake object that needs to have its `cellsToGrow` field accessed and modified by two public methods should be able to modify its own fields. But for some reason the value change does not seem to persist after the `AteApple()` method returns.
As it turns out, I was passing the snake by value, which copied all data. I should have been passing the Snake by refernce, allowing the changes to be made to the on going snake object.

Automation Design::

How, in human terms does the snake move in the most basic implementation of a Snake AI?
In short, the snake should move according to a Hamiltonian Cycle. That is, a list of indexed positions that covers then entirety of the grid, and ensures that the last index connects back to the first index. In a 2 x 2 grid, this looks like a simple loop, while bigger grids can have many more options for possible cycles. Note:: Hamiltonian Cycles defined in this way must have at least one side that has an even length to allow the cycle to be completed.

How do intend the design of the cycle?
While it may be a bit tricky to get exact, I think that implemeneting a deterministic hamiltonian cycle will be the simpliest. Namely, have the generator assign the top left corner 0, count up by 1 until it reaches one less than the width of the grid, then move down by one row, and go left until it reaches one cell to the right of the left edge. 
    If at this point it has reached a veritcal that is one less than the grid height, move one more to the left and go up until the top left corner is reached
    Else, move down by one and start the [all the way left, down one, almost all the way right] cycle again.

How do intend to implement this design?

In theory, I could do this a couple of ways, I could have this algorithm apply the above logic every time the snake needs to be updated, which may be a bit cleaner.
Or, I have a vector of cell objects which are created and added in order of the above. Then, when the snake is updated, it passes its head position, and is returned an int,int vector with the direction to move.

At this time, I really prefer the latter.

A Hamiltonian Cycle class stores a vector of what? It occurs to me that I have a couple of options. I can have the cycle class store a vector of int vectors which store only the positions. Or I can have them store objects (maybe Cell objects) that can be more flexible (ie, can be easily rendered to the screen with their index for testing).

Despite the implied memory overhead, again, I am thinking I will go with the object. Though I will need to create sibling to the current Draw() that draws the index instead.

## After initial implementation

I have an almost working version. The snake moves around the grid, even a big grid, and will successfully go from the start of the list to the end. Unfortunately, there seems to be some crash I am yet to really specify when the snake fills up the screen which is presumably the source of the lack of on screen victory text rendering and the console message. I do not have trying to debug that in me at the moment, and I have a lot of school work to do. That said, to try to raise my energy, I am going to try to get a bit of house work done before I start on homework. 