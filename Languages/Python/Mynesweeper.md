# Mynesweeper

I am restructuring my approach to Mynesweeper. By which I mean I intend to make a more deliberate plan about how I will go about designing and building Minesweeper in Python, as I did not really use Python's features well and ran into issues regularly.

The goal of the project is to recreate the classic Windows game Minesweeper using Python, likely leveraging the tkinter libaray to help with graphics and user interactions.
While I am not certain, I am going to try to determine if there is significant benefit to creating a fully functional console version of the game before implementing a graphical version.

Noun, Verb, and Adjective Test for OO Development:

The game of MineSweeper presents the player with a /grid of cells/, each of which can be in one of a few states*, but all /cells/ always begin 'closed', showing a simple square icon. The /player/ gathers information from open /cells/ about what closed /cells/ to open next (and which ones not to), aiming to avoid opening /cells/ that contain /mines/. Players can 'open' /cells/: once a /cell/ is opened, it cannot be closed again. /Players/ can 'flag' /cells/: this places /a special marker/ on the /cell/ that the /player/ believes there is a /mine/ within this /cell/. /Players/ can 'unflag' /cells/, to allow /players/ to correct mistakes. Any /cell/ in the 'flag'/'flagged' state, should not be openable unless the /player/ removes the /flag/, as to forgive misclicking on cells known/believed to be /mines/.

*These states are closed, flagged, and open. Open states fall into two (2) categories. The open state can show a special symbol, indicating a mine is present**. The other open state varies from showing 0-8 within the cell, representing the number of mines in the eight (8) adjacent cells. In the case that the player opens a /cell/ whose state indicates there are 0 neighboring /mines/, the game should automatically open all adjacent cells recursively as a convienence.

**In the case that the player opens a mine, the game is lost. For clarity, the game typically shows all mines on the board when any one of them is clicked.

Nouns: /MineSweeper/, /grid of cells/, /cell(s)/, /player/, /mine(s)/, /a special marker( or flag)/, /icon(s)/

Cell: 
    Adjectives:
        Open
        Closed
        Flagged
        Number
        Mine
    Verbs:
        Opened
        Flagged
        Unflagged

Grid of Cells: 
    Adjectives:
        Width
        Height
    Verbs:
        Reset

Player: 
    Adjectives:
        Win/Loss State
    Verbs:
        Start Game
        Open Cell
        Flag Cell
        Unflag Cell

Pseudo-UMLs

---Cell(tkinter.Button)---
==Variables==
==Fields==
    state: Any
    mine: Boolean
    count: int
==Functions==
==Methods==
    open: Boolean
    flag: Boolean


---Grid---
==Variables==
    difficulties: dict()
==Fields==
    cx: int
    cy: int
    mine_count: int
    grid: Cell[][]
==Functions==
    get_x(): int
    get_y(): int
    get_size(): (int, int)
    get_difficulty(): (int, int, int)
    generate_cells(x,y): None
    assign_mines(grid): Cell[][]
    count_mines(grid): int
    assign_neighbor_count(grid) Cell[][]
    # More with assigning mines and counting them
==Methods==


Note: Based on past experience, I will need to think carefully about how to represent my data, and how to properly reference the sprites the game will use. I was just reminded of MVC, which I am going to remind myself of explicitly. It makes the most sense to deal with storing and assigning sprites in the View. Though this has made me question the wisdom of using Buttons of each cell. If I take a large clickable space as my input to the Controller, map the mouse x and y to a cell based on the difficulty, and generate an open/flag/unflag 'event' for the assigned cell on a left or right click, I don't have to deal with buttons, but can just deal with labels. This design also means that a simpler model design is also possible, where each cell has a single 'state' variable, and a few others that track what the state can be: mine, open, and count. When the Controller indicates that the cell has been opened the state resolves based on the mine and count variables. When the contoller indicates a flag/unflag input, the state moves between open and flag accordingly. 
Model: The structured data that lies behind what the user sees.
View: A ruleset for visualizing data stored by the model.
Controller: A framework and ruleset for outside elements interacting with the Model and View, makes changes to models and requests that views are generated for    

### Deprecated
I am really struggling with my attempt to create Minesweeper using Python and Tkinter, and I think there are a few causes interacting.

1. I am not fluent in Python at this time. I have syntax and general concepts, but dealing with proper Object Oriented implementations is not something I am confident in.
2. I am not fluent with Python's lambda expressions. I have found information online that suggests that lambda's are always pass by reference, unlike the seemingly standard pass by value for primitives.

After finding [this](https://old.reddit.com/r/learnpython/comments/nary8j/tkinter_pass_reference_to_self_to_lambda_function/) reddit post, I realized that I can in fact pass the x and y of the cell by value in the constructor, and assign the constructor to bind the cell (being a subclass of Button) bind the propper action to itself.


## 1. Additional Features

1. Allowing users to specify sizes and possibly mine counts, which are then passed to the Constructor to create the board by parsing a string containing a 3-tuple.
2. Red Highlight Sprite for the mine you clicked on, and showing all mines when any mine is clicked.
3. Dev-Tool: A script that will run all tests of MyneSweeper (but not my micro test file).
4. A text implementation action to click a random tile (useful on the first move).
5. Zero-Spreading: Note: Corners around 0s are openable
6. Refactor Assigning neighbors counts with neighbor list
7. Write tests for Added model methods

## 2. A Change Up

I am currently implementing Zero Spreading (which is super important to make the console version not super tedious), and I am running into a lot more issues than I would have thought.
I don't think I can really blame Python in this case, as I am just not using the tools at my disposal and am failing to implement rather conveluted logic correctly. This has had the effect of creating what I am all but certain are infinite loops, seeing as I wait several seconds for a 2x2 grid of empty cells to be zero-spread and nothing happens.
While I could spend an unknown amount of time trying to trace through the problem, it occurs to me that there are a couple of structural flaws that have made this project harder than they need to be.

1. Cells don't know their own positions.
2. Cells don't have a `checked` field that would allow easy flood filling without creating infinite loops.

In intend to implement both of these fields next, as doing so not only solve the listed problems, but remove the need for the `get_cell_pos()` method.

## 3. A Lesson

Early on while builing MyneSweeper, I made the decision that I wanted to store the grid as rows of cells, not columns of cells. This was a mistake.
This means that in order to index a cell, you must put the y value of the cell as the first array index. In situations where you are iterating over the entire grid, like assigning mine counts, the order x-y order is not relevant as long as the bounds for the iteration variables align with the bounds for the array.
While trying to implement zero-spreading, I swapped to using an x-y pair instead of a y-x pair for accessing the cell I needed. This meant that when I was openning cells along the diagonal from 0,0, a diagonal stripe would be sucessfully opened, but as soon as I moved off of the diagonal a ways, the zero-spreading did not open a single cell.
The use of an x-y pair is ingrained into me, and while I do think that I benefitted from 1) making a mistake that I have been able to compensate for (gaining flexibility in how I go about things) and 2) understanding that the typical implementations (like the x-y ordering for pairs) will make implementations a lot smoother.



## 4. An Issue

I have come across an issue with TKinter and have read somethings about TKinter that do not inspire confidence in it.
The issue is that when the mouse enters and leaves the game window, all of the sprites redraw, and I have no sense of why. Information I have found online suggests that UI elements should only be redrawing when events that I give definitions to are called that require an element to be redrawn, yet I get a pretty obnocious (sic) flicker when the mouse enters or leaves the window.

As mentioned, I have read online that TKinter is a legacy GUI library, and that more recent ones are more appropriate today. I found [this](https://www.geeksforgeeks.org/python/python3-gui-application-overview/) list from GeeksforGeeks compiling various Python GUI libraries, and found a couple potential options.
I should also address that multiple on that list also provide tools that allow the developer to create UIs with drag and drop tools. In theory these make creating UI's simpler, but in my limited experience with JavaFX and SceneBuilder, they are a blight on the world. I recognize that there are likely more intuitive implementations in these Python UI builders, I am a more experienced developer, and I have more screen real estate. But I am not looking to change my ways on this topic at this time.

Options:
TKinter
Kivy
Streamlit
PyQt - Wide userbase, lots of docs, flexible, performant,
WXPython - Seemingly a more advanced tool (some notes are copied from another entry, making specific benefits unclear)
Libavg - Multimedia focus (should handle the images well), though limited documentation

Second Options
PySimpleGUI ? Active userbase, may not give the flexibility I need


Non-Options
PyForms X Intended for advanced form submission, uses designer tool
PyGUI X Includes designer tool

Another question I need to ask myself is if PyGame is more appropriate for the context. Ultimately, I think that it is more appropriate to use a game framework fo recreate games, though I am no longer getting more familiar with UI tools.
With that, if I decide to come back to MyneSweeper, I intend to look at PyGame for the tools I need. For now, I think I am going to look at other projects that are more dev-tool / productivity related, and build them using a UI tool.

## N. The Last One

This section is a short placeholder to ease the expansion of this document, allowing previous elements to remain folded when new elements are added. 