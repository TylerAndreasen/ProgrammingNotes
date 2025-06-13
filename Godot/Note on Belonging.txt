Excuse the flowery title, I can't come up with what else to call this.
In watching a tutorial, I came across an interesting point, the voice over explained that a character should not belong directly to any level, but to the world Node that manages the player and the level.
For Flappy bird that is not necessary, as the player will never move between levels per say, but it is an important note.
What precisely Nodes belong to is important, and swapping out the currently pointed at level while maintaining the Character is easier and will allow for greater ease of use than cycling through levels, each of which has their own Character instance.
Reducing duplicate code (maybe), and other benefits.