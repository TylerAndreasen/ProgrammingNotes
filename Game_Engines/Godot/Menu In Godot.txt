https://www.youtube.com/watch?v=sPfoZy-cW-E

This tutorial explains all of the UI Nodes in Godot, and has a lot of helpful information, I have local project which is a sort of recreation of the example settings menu shown at the start. There are several things I have learned and want to document here.


1. For Settings menus and the Like, the TabContainer is fantastic. It handles creating a tab menu for you. I have Audio, Video, Gameplay, and Controls as separate tabs, and intend to create appropriate options for each (though they will not be functional as I am just learning how this all works. Each child of a TabContaineris used to create a separate Tab in the header and will be the parent of everything shown in the Tab. I have the four listed tabs as VBoxContainers so that a list of options can be shown in each Tab.
	It does occur to me now why so many games have an "Apply Settings" feature in their settings, as pressing apply explictly can trigger an set of checks to apply any changes, rather than doing so constantly or when a user unfocuses any UI element.


2. As a rule of thumb, there are going to be A LOT of things in the UI heirarchy. In order to create good looking UIs, you will need to add padding, backgrounds, boarders, and other elements of visual heirarchy. Making UIs is something I should practice, a lot. And getting used to how many things are in the heirarchy is important.

3. One difference I noticed between my menu and the example was that I had quite a lot of blank space in the VBC while the example's did not. The reason is I put the TabContainer in a MarginContainer. This makes the tabcontainer fill out to all but 100 pixels on each edge. A handy trick, but something I forgot and wanted to call out.

4. OH SHIT. This is going to revolutionize things. I was walking frame by frame through what the UI Node video was doing, and the guy selected all three of the Audio control Labels by control clicking each and then changed all of their vertical alignments at once.

5. Scrollable lists are made easy by the ScrollContainer. Have either a VBox or HBox within, and assign the appropriate scroll direction, and add elements to the added Box, and you can scroll through options at runtime.

6. MenuButton - A button that when pressed creates a drop down of selectable options, to choose between. Seems quite handy for choosing between just a handful of options, like say the V-Sync options.

6.1 OptionButton - shows a down arrow to indicate a list. This is visually more clear about it's being a list of options. Probably use this one instead.

7. ColorPickerButton - displays a color picker, great for assigning colors to elements within the game for accessibility and aestetic purposes.