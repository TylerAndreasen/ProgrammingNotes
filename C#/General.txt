General Notes

1. PascalStyle is the default for C#. This means that all of the individuals words (including the first) in symbols should start with captial letters and include no underscores.

2. Classes and Structs - Classes in C# operate pretty much as expected, and are used in the same way that Java Classes are. Structure Types or Structs are intended to operate almost like JSON objects it seems. More complex than a String or a primitive, containing little to no functionality within it. The example given by Microsoft is a struct call Coords, which stores the doubles X and Y, and the overridden method ToString() which returns $"({X}, {Y})".
	I could see this type being the basis for how multiple door puzzles function. Those puzzles which present to the player some number of levers and some number of doors, and flipping any lever will cause doors to open and close. And the puzzle being to determine the arrangement of levers to open all doors at once.

3. Local Functions - I like these, they are quite interesting. A Local function is a function defined within a member (probably another method/function, but could be defined in a property I suppose), and is only callable in that method. This has several advantages, most boiling down to encapsulation, incorrect calling, and privacy.

Specific Items

1. The '?' operator makes or specifies that the type of the variable used is Nullable, that being an instance of the struct System.Nullable. This indicates that the variable can have a null value, and this can be tested for with IsNullOrEmpty(VarName). This makes quite a lot of sense when taking an input from a console or other user input.

 string? input = Console.ReadLine();
 if (string.IsNullOrEmpty(input)) break; //Inside a loop

2. Literal Strings can have data easily inserted into them by placing a $ before the literal. Inside the string, place a pair of curly brackets, with the desired value inside. This can be as simple as a numeric or otherwise variable, the result of a simple expression, a turnary operation, or possibly a full method call.

3. The value Environment.NewLine is awesome. Using the symbol in source code indicates to .Net compilers on Unix and non-Unix systems to insert the correct manner of generating a new line in text. This is used by methods like Console.WriteLine and StringBuilder.AppendLine.

