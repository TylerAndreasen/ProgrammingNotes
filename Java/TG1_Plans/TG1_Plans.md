# Text Game 1

I have a bit of a wild hair to write some thoughts out about what the proposed structure of the game might look like. I want to make clear to myself that I am not marrying myself to the ideas I express here, and that I need to be willing to let go of these ideas if and when they become obsolete in achieving the goals and User Stories for the project. What follows is musings that may help myself and others get idea about how we might go about achieving certain goals.

[REDACTED] and I have discussed a little about how we intend to represent the game's structure at a high level. I think it wise for us to represent a world that a player moves around within, rather than a tree of decisions that can't be climbed back up. Whlie the latter is a perfectly valid way to make a text game, I believe that such a structure limits the maintainability of the game, requiring more and more effort to make changes and add more nuanced elements (ie, puzzles that the player can walk away from). The former option, I believe, will take more effort to set up, but should allow for easier expansion as the semester progresses from both a technical and writing perspective. Namely, keeping objects as state registers for puzzle elements, door locks, other agents in the environment, and more enable the team to represent and track many dynamic elements without create a decision tree with many (near-)identical elements.

Another point to be made is that the design I intend to describe here will need to be implemented in phases through multiple User Stories, and should be built with future development in mind. How would I want the game to be structured at a high level?

The core of the game is the loop. When the game starts and enters the loop, the game presents information about the location that the player starts in and prompts the player to give input. Once the player has given input, parse. In the case that the input parses into invalid data, jump back to the start of the loop. In the case that the input parses correctly, act on the intention that the player expresses. This might be moving to another place, interacting with something or someone, or something else (inventory? this may be a rather complicated endeavor).

This is where the structures that the character interacts with is important, and tricky for me to conceptualize and describe. The simplest unit for this situation is a Room which is capable of describing itself to the player (or providing a description to another system with that responsibility) and the which player can move between (having a pointer move around a Graph, wait for later in Discrete). For a version 1, I think it is appropriate for this functionality to be directly in a Room class, but as the engine grows, some of that functionality should be moved into an interface that can be extended by things that do or do not share functional structures with the concept of a Room. I say this as I believe that there is great value in eventually implementing an idea of a Point of Interest (a class/interface perhaps called POI) that instantiated within a Room, and a player can investigate POIs without changing Rooms. Then POI subclasses/implementors can provide functionality that are appropriate for the context (art on the wall can describe what it looks like, a chest can store it's locked state/contents, a door can store its locked state/material, and the like).


### Nesting

After further conversation, it was expressed that the structure of the game should remain flexible. Generally speaking, there will be a Graph representing the explorable places in the world, and interactable things inside of it. From a structural perspective, this might look like an ArrayList of Room objects which point to each other, and within each Room is some number of things, perhaps called Features. Rooms and Features have descriptions which are printed to the player if the object is focused.



**************
# JUnit Test Ideas

?? How to simulate user input with JUnit. This may require command line params which differ between automatic testing and manual execution to switch what input stream type (Scanner(System.in) versus other input stream) method is listened to for testing purposes.

1. Start game. Store output from starting room. Simulate input that does not parse properly. Assert that the stored output matches the second output. (Note: Adjustments may need to be made if debug information (including "unreadable input" message) is output when unparseable input is given.)
2. For a given story build, simulate a series of actions, then assert that the output matches the expected output for the story build. (Note: If the project includes the discussed 'fun' value, borrowed from Undertale, this will need to be taken into account.)