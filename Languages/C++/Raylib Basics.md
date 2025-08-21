# RayLib: Basics

I have been working with raylib for a few weeks now, and should really take some notes on the basics of how to use it. As implied, this is the basics of the framework, not the more advanced things I will need for future projects. This document is indented for 1. my future self when I take a break from raylib and come back confused about how things work and 2. others who have not used raylib before, have found this repo, and want to tutorial for how raylib works in a text form.

NOTE:: This tutorial is written with the assumption that you have some experience with C++ and at least basic familiarity with 2D graphics conventions (namely the origin being in the top left corner and the positve axies being to the right and down). 

## Contents

1. Install
2. Validiate Install
3. Minimum Project
4. Important Functions

## **1. Install**

This is a bit of a cop-out, but I do not have the time, patience, or expertise to explain how to properly install ryalib at this time. Therefore, I provide this [link](https://www.youtube.com/@programmingwithnick) to a video by one `Programming With Nick` who explains the install process pretty clearly. Note: You can likely follow the linked tutorial and skip sections 1-3 of this guide, and reference only the Important Functions listed in section 4.

## **2. Validate Installation**

If you have raylib installed and want to ensure you can actually use it, this is a pretty simple task. Copy the below code into your editor of choice (I use the community version of Visual Studio as I needed to do 0 set up to get it to run C++ code, where you would need extensions and other hassles in VS Code.)

```c++
#include "raylib.h"
int main()
{
    return 0;
}
```

If the above code compiles and runs, then your install of raylib exists and is accessible to your development environment.

## **3. Minimum Project**

The below is a minimum project to show that raylib not only compiles, but can create a window with graphics. Feel free to use this as a basis for your own projects, as you will need/want most every line in this code for any larger raylib project.

```c++
#include "raylib.h"
int main()
{
    std::string showText = "Hello Graphics!";
    int fontSize = 40;
    int screenWide = 1920, screenHigh = 1080; //These are local variables, which will will assign to the window, not the names that raylib uses

    InitWindow(screenWide, screenHigh, showText);
    SetTargetFPS(60);

    while(!WindowShouldClose())
    {
        BeginDrawing();
        ClearBackground(BLACK);
        DrawText(showText, 100, 100, fontSize, WHITE);
        EndDrawing();
    }

    CloseWindow();

    return 0;
}
```

## **4. Important Functions**

raylib is a huge library that I have just scratched the surface of. I will begin by explaining the functions in the Minimum raylib project from above (mostly) in order.

1. `InitWindow()` and `CloseWindow()` - As are many of the raylib functions, the name is pretty indicative of what the method does. The `InitWindow()` is provided the desired width and height of the window to be created, (optionally?) followed by the desired title for the window. This window is what drawing occurs on (see below), and should always be closed before the rest of the program ends. I am unsure if the name can be passed to ensure that only one window is closed if multiple windows are open, though I am unsure how raylib handles multiple windows at this time.

2. `SetTargetFPS()` - This sets the desired maximum frame rate that the Window will run at. This is quite important, as not setting this will indicate that the screen should update as frequently as the rest of the code and the screen will allow, likely causing any moving graphics to run much faster than desired.

3. `WindowShouldClose()` - This returns true if (by typical UI behavior) the window should close, if the user pressed the `X` button in the top right of the window, or pressed escape. For simple games and graphics contexts, this is fine, but if you want Escape to pause the gameplay and open a menu, you will need to take a different approach.

4. `BeginDrawing()` and `EndDrawing()` - These methods tell raylib that the functions that lay between them should all be rendered in one frame, and `EndDrawing()` (I assume) sends the pixel buffer within raylib to the OS that the program is running in. I have forgotten this line a time or two when building projects and was quite confused with nothing appeared. Equally important but not listed is the `#include "raylib.h"` that I have forgotten about as many times, though luckily not when I typed out the above example.

5. `ClearBackground()` - This sets all pixles to have the color passed into the method, acting as a way to clear the buffer from the previous frame. Fun could be had with not doing this, and using shapes and opacity to get rid of past game states visually.

6. `DrawText()` - This method draws text to the screen. This is done by passing a string to the function, followed by the top left corner of where the text should appear, followed by the font size of the text, and the font color. Many if not all drawing methods in raylib use this strucutre, though few if any others include a leading string argument.

And that concludes the methods from the example. raylib is a huge library that can do a huge amount. Below are serveral similar examples, and lists of methods that I have used.

1. `DrawRectangle()`, `DrawCircle()` - Draws the relevant shape by its top left point, the relevant size parameter(s), and a color.

2. `IsKeyDown()` and Key Codes - In order to build a game, the player must be able to provide some input, and we are not making a Zork clone here. The `IsKeyDown()` method gives you the ability to ask raylib (which asks the OS) if the user is pressing a given key in this update cycle. In order to use this properly, you will need to provide the key code of the key you are interested in. Luckily, raylib abstracts this by creating constants for most every key (and I think gamepad input). These are in the form of `KEY_` followed by the name of the key, so the keys A, F, 5, F5, and Enter would be `KEY_A`,`KEY_F`,`KEY_FIVE`,`KEY_F5`,`KEY_ENTER`. Other specific keys can be found within the list of IDE suggestions for `KEY_`.

3. `SetExitKey(0)` - Without having used the method, I can only assume that the method assigns the only key that 

At this time, these are the only rayib specific functions I have used, though there are many more I will need and further exploration of more advanced tool can be found in my RayLib: Advanced file.