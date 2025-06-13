VS Code is a text editor with features that allow you to find and edit code easily. It is not an IDE, I did not understand this and confused me greatly.

Visual Studio is an IDE that allows for execution of code natively in a handful of languages.
VS Organization

	Solution - Not totally sure what this is, other than a super high level wrapper. Really, it seems like it manages what corporate and high level development people would call a project.
		Project - seems straight forwards, its a collection of code, execution details, and some other overhead to get the code to execute. I assume (though have not tried) that code can go into folders therein, and be easier to manage. Or I have this all sideways and Projects are folders within Solutions.


NOTE: Create a Solution from the 'New Project' menu in the ribbon. Then select solution from the window. This will shift VS into the solution. Then create a new project inside the Solution. This gives the necessary boiler plate and overhead to get the program to function.

At this time I am unsure how it is intended for you to be able to see a console in VS itself, or how to otherwise have printed lines remain readable after execution (as the console window that appears to display written lines disappears when execution finishes). :: I have toggled this on, and instructions for how to turn it off within the environment also print, which I plan to leave on in the case I want to switch it back off for something.

The tutorial I am following is for VS2022, so I installed that, which should make the tutorial easier to follow, as the UI should match closer to the images and descriptions.

https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio?pivots=dotnet-8-0
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/

The Library :StringLibrary:, needs to be added to the dependencies of the console app :ShowCase: in order to be usable. These are two different Projects within a Solution.

Questions:
	What does :string?: mean as oppsoed to :string:? The trailing :?: indicates that the string is nullable, and that there is potenitally no value stored. This is advisable because the example that showed this to me was taking input from the user, who could easily hit just enter and send no meaningful data.
	Why is the ResetConsole() function written the way it is (namely clearing the console)? Need to understand what it does better first.
		There are a few things. 1. I think its purpose in clearing the console is to keep the console clean and avoid needing to have a giant window to see everything on screen. 2. I realized that the ResetConsole() method was written inside of the main method of the class, and had no access modifiers. This is called a Local Function in C#. Being related to Lambda expressions, Local Functions are written inside other functions, have access to the variables within the containing function without passing them as arguments.