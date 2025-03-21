# Snake Responses

I had my Dad play my Snake game. As I expected, talked about the inputs, mentioning that they almost feel like they need to be on a beat. I do like the idea of having a Rhythm Snake game, though not the goal at the moment.

From what I saw, and what he said, it was very easy to have the snake turn early, indicating that maybe the update code should run before checking for the user's input on update frames.
I do want to try implementing an Event Listener type system that will store inputs from the user, and play them when the next update happens.
Apparently raylib does not implement the sort of feature I am looking for, there does not seem to be a OnKeyPressed() method that can be defined within the user's source to have executued whenever keys are pressed. 