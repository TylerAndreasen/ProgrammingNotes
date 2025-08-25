# Visual Studio Code

### Hotkeys

#### Running and Debugging Code

`F5` - Attempts to run the selected file. For files that do not have an entry point for the contained language, VSC will either raise an error or simply not execute the code. Ensure you select a file with an entry point to run. I have annoyed myself on a few occasions by editting a file that defines an instantiated class or some other functionality and the code not running upon pressing F5.

IMPORTANT: Use Break points if you are trying to debug, as they allow you to actually look at the values in medias res, and make the follwoing hotkeys meaningful.

`F10` - Step Over - This executes the next line of code when the debugger is not in a running state. Once a paused state is reached, the debugger will wait for an input to execute the next line, or more granular input.

`F11` - Step In - If the following functionality is not applicable, this operates identically to pressing F10. In the case that the line to be executed contains a call to another method (in the language the program is written in), the debugger will jump to the definition of the method being called. This allows the user to follow execution of program down into other parts of the code base.

`Shift + F11` - Step Out -  If applicable, the code will continually execute until some return like statement is reached. Being the counter part to Step In, this allows the user to quickly return to calling methods after entering a called method.