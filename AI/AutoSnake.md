# AutoSnake

I have previously built a Snake game using raylib in C++, and a version which uses the idea of a Hamiltonian Cycle to make the snake win.
This satisfies the idea of a Snake AI but does not learn, which is something I would like to do with this project.
The question becomes, How do I go about training such an agent?
At one level, I think I could set up a neural network that learns to take in the states of a game of snake, and outputs the best direction to move.
Note: Previously I have been fairly resistant to using existing libraries for things like management of a neural network, though I am no longer convinced of the benefit of this high-minded resistance.
In this case, how do I set up the network, and what else can I do to make early training easier?
1. I will need to 