# C++

Below are things I have learned about C++ that I want to make note of. Much of the basics of C++ is the same as C or Java, but there are a number of things that must or can be done differently.

### **1. Using Multiple Files**

When working in Java it is almost trivial to build a system that includes code from multiple classes in multiple Java files. This process is made somewhat more complicated when placing classes into folders, but is fairly straight forwards with an IDE to resolve (though moving between IDEs can be a problem if they are not set up to work together).
Things are not so simple in C++. At this time, I would understand the following to be the requirements for using code from multiple files in a project:

* The Include Declaration: In order to use code from one file in another, a declaration like `#include <iostream>` must be placed at the top. This particular include adds functionality (I believe) related to communication with the console. Another example would be `#include "raylib.h"`, this adds in the header file for the main raylib library. Further, I have seen recommendations online that you only add include statements in header themselves that are absolutely necessary for any implementation of the class to function, where specific includes can be included in implementation files as needed. But what's a header file?
* The Header File: A header file (specified by name.h) in C++ defines the major components that will be within another name.cpp file. From what I read in a single StackOverflow post, these exist largely for the benefit of the linker, a component involved in compiling C++ code into machine instructions. NOTE:: Header files should contain everything that the `.cpp` file does that is not implementation. Methods have no bodies (ended with a `;`), and parameters are a comma-separated-list of types, with or without names, variables and fields are given types and names but not values, unless those values are `static` and `const`.
* The New File: The final component of using a new file in your main file is making the new file and writing code inside it. IMPORTANT:: Both the .cpp file in which code is to be referenced within and your name.cpp file must contain `#include "name.h"`.

NOTE:: While not mentioned explicitly, I have come across information that would suggest rules for the use of angle brackets and double quotes in include declarations. Namely, I will use angle brackets for native C++ headers only, and use double quotes for secondary library and project headers.

### **1.1 Classes Across Files**

C++ allows the developer to implement proper classes, instead of just structs. But implementing classes with header files slightly complicates the situation. To implement a method from a header file inside a `.cpp` file, the declaration of the method must follow this standard:
```c+++
    returnType ClassName::methodName(paramType paramName, ...) {/*Method Implementation*/}
```
As far as I can tell, access modifiers (and the `static` keyword) are not specified in the `.cpp` file, those exist only in the header file. Which is sensible given my understanding of header files as the outward interfaces important to developers using the supplied code.

NOTE:: I spent several minutes trying to diagnose why a method I pasted into both the header and `.cpp` file was showing as not matching the header from the `.cpp` file. I resolved this issue after I realized that there was a type-not-defined sort of error in the header file that was not being called out with a red squgilly line underneath in the header file. In short, I was referencing things like string and vector as types in the parameter list and the fields for the Vertex Class of QuickGraph, but had not declared their inclusion at the top of the header file.


### **1.2 Moving from Single File Implementations to Multi-File Implementations**

At times it is easier to implement a test of some functionality or idea in a single file, which contains all of the code for the class, and the main() method which will operate on the code. There is a time and a place for this approach to development in C++ but I find myself tiring of the hassle that comes along with moving from a single file to multi-file implmentations of the idea, especially as I do not intend to create separate solutions when doing this sort of shift (though perhaps I should if I ever take this approach again). 
There are a few sources of frustration when making the move from a single file to multiple.
1. Method Declarations:: When implementing a class in a single file, the class can contain every element it needs to function as a class. When following language standards for C++, the header file contains essentially a series of sections of the original implmentation, while the new `.cpp` file contains everything the old file did, minus the class declaration, plus the `#include "relevant.h"`, plus the token `ClassName::` preceeding every method declaration that is implemented the `.cpp` file. (See:: OOP may imply that not all methods declared by the header file are implement by a `.cpp` file of the same name. As such methods may need different implementations for different subclasses, though I am unsure how to implement a subclass at this time.)
2. Type Shenanigans:: As mentioned in *1.1 Classes Across Files*, (I believe) link-time issues can occur when needed types (string, vector) are included in the `.cpp` file using them extensively, but are not included in the header file which includes those types in the parameters and class members. I do find it slightly strange that there is not an early error message for this in Visual Studio. This however may be the result of my not understanding when that sort of check can be done in the journey from source code to on-screen execution.

### **2. TODO C++ Style Guide**

This section is dedicated only to the style of C++ as a language, not the function of the parts described.

1. Defining Classes : Classes in C++ are fully defined in two parts (just as variables are). And this takes the form of two parts: the header file, and the implementation file. This separation of definitions creates a huge flexibility that I do not fully grasp the consequences of, as header files can be defined in one place for basic behaviors, and local implementations can be made in files that are not a solely dedicated to that class definition.
    1.  The Header File supplies class member declarations. Variables and fields are defined by their types, modifiers, and names. Functions and Methods are defined by their access modifiers, return types, names, and parameters. The Header File also seems to be the intended place for constant class variables. Given the nature of C++ compilation, care must be taken with how header files are used and defined. It is quite easy to define a simple header file, try to use it and get compile errors. This is because a class definition can only exist once within what the linker is aware of, which is easily broken if a header file is included in both the implementing class file and the main() file. See the below alert for more information about how to
    2. The Implementation File supplies the runnable code that is executed. All code within this file must have a declaration within the header or will cause a compile error. Note: It is convention with C++ to create paired header and implementation files, for which the latter implements all members of the former. It is possible however to implement members in multiple files, varying the implementation in each. And it is one of the greatest strengths of C++ (from what I would understand) to create multiple implementations in different translation units. Allowing classes to be given a structure in one place, and have the implementation vary based on use case (including things like variations of NPC AI).  

> [!IMPORTANT] 
> The creation of a header must handle only allowing the header to be linked once. This can be done in one of the following ways. I have seen commentary online that the latter is preferred, despite Visual Studio creating the former by default.
> Option 1:
> ```
> #pragma once
> //some code here
> ```
>
> Option 2:
> ```
> #ifndef CLASS_NAME_H
> #define CLASS_NAME_H
> //some code here
> #endif
> ```
>
> It is important to note here the style used of defining the header. The name of the header is in all caps, with underscores to indicate spaces, and a trailling `_H` to indicate the symbol is defining a header. See `Addmission` below.

2. Using Files and Classes : Referencing code, including classes, across C++ files is not as simple as it is in Java, for example. In order to reference code outside the present file, you must place an include statement at the top of (or at least inside) the relevant C++ file. The include statement for the native iostream class (handles console IO) is `#include <iostream>`. The `<>` specify that the code is not local or specific to the program you are writing, but is a library file (be it native C++ or an outside library being used by your program). To reference a header file defined within your program use a line with the structure `#include "headerName.h"`. The use of double-quotes and a `.h` file type specify that the header is within your program. Further the double-quote syntax (AFAIK) allows for defining relative roots from the current file to the location of the header file being included allowing for both version control and careful code management.

3. Describing Code Blocks : At this time, I do not know much about the standard ways to go about commenting C++ code properly. Visual Studio does seem to allow the use of a`/**/` block before a Class or Variable to document it, though I am unsure if this is proper procedure. 

4. Equality Testing : Deriving from C, C++ allows ints to be used as booleans for equality testing. This means that statements like `if (x = 0)` will assign the value of `x` to `0`, read the value `0` within `x` as false, and not execute the block. This is likely to occur when the intent was `if (x == 0)`. This problem gives rise to the style of placing constant values before variables in equality tests: `if (0 == x)`. As mistyping this with only one equals creates a compile error. 

<details>
    <summary>Addmission</summary>
    I ran into an issue with a header definition and a method argument both called `ball`, in which the header definition took priority over the argument name, but the only error message I recieved was that the line `ball.getY()` had an error on the `.` of `expected expression` which was completely unhelpful. See Seciton 6. Identifiers
</details>

### **3. TODO C++ Style on "" versus <> Include Statements**

I have seen some discussion online about the use of "double quotes" and <angle brackets> in `#include` statements in C++.
As of the time of writing, I intend to:
1. Use <angle brackets> when including native C++ header files, and
2. Use "double quotes" when including any library or my own code.

These are quite simple guidelines (which may cause some grumbling from the opinionated), and a ruleset that I can easily follow (See:: several months from now when I have undoubtedly taken some time away from C++, forgotten that I have written this, and completely ignored any standard for how to include things in my code). Note:: I do not plan to retroactively update all of my code with these rules in mind, as I honestly imagine that I will never touch most of it again.

### **4. Console IO**

I have seen discussion online about how best to go about interacting with the console in C++ and don't totally understand the information I have found. In short, the recommendations I have seen are to:

1. Do not include a `using std;` declaration in any file. The reason given is not super clear to me, something about conflicting member names, though this seems a little thin of a reason.
2. Just Type `std::cin/cout`. While there are not that many characters in `std::`, it feels quite disruptive to type out any time I want to print information to the console.

These suggestions seen and noted, I have two other options I am aware of at this time:

1. Include a `using std::cout;` declaration. This allows me to simply type `cout` to write to the console with out shoving every part of the standard library into the build, sidestepping problem 1, while not having to engage with problem 2. This can be made more useful when the line is expanded to become `using std::cout, std::endl, sted::cin;`. This syntax allows `cout`, `cin`, and the constant `endl` to be used without the `std::` prefix. NOTE:: The multiple using declaration shown to apparently requries version 17 of C++, which I do not have installed or configured for this project, individual `using` declarations can be used.
2. Hotkeys: I could, with a bit of time, implement C++ specific hotkeys that allow me to type longer instructions with a few keys. Implementing hotkeys for the full printing or reading statements could dramatically speed up my C++ development process, and push me to build more hotkeys for this machine.

### **5. Argument List**

I have just discovered something quite strange about arguments. Whatever compiler I am using apparently does not allow comma separated arguments to lack spaces between a comma and the subsequent arguement. While it is much easier to read a program when this is not the case, I was surprised to find that a compile error was generated.

### **6. Identifiers**

After several hours of not understanding an issue, I have figured it out.

Error: When compiling my first RayLib Experiment, the compiler would generate a syntax error for the following.

`cpupddle.cpp`

    float targetY = ball.getY();

Despite this, the Ball class was defined as follows.

`ball.h`

    #ifndef ball
    #define ball
    /*

    Defines the behavior for the bouncing ball in the classic game Pong.

    */
    class Ball
    {
    public :
        Ball();
        Ball(float, float, float);
        void Update();
        void Draw() const;
        float getY() const;
        float tim = 7.5;


    private:
        int x;
        int y;
        float xSpeed = 7.0;
        float ySpeed = 7.0;
        int radius;
    };
    #endif

`ball.cpp`

    #include <raylib.h>
    #include <iostream>
    #include "ball.h"


    using std::cout;

    Ball::Ball() : Ball(400.0, 300.0, 10.0) {}
        

    Ball::Ball(float x, float y, float radius)
    {
        this->x = x;
        this->y = y;
        this->radius = radius;

        cout << "Ball Init X: " << this->x << '\n';
        cout << "Ball Init Y: " << this->y << '\n';
        cout << "Ball Radius: " << this->radius << "\n\n";

        //cout << "Screen Width x Height is: " << GetScreenWidth() << 'x' << GetScreenHeight() << "\n\n";

    }

    void Ball::Update()
    {
        if (this->x + this->radius > GetScreenWidth() || this->x  - this->radius < 0) this->xSpeed *= -1;
        if (this->y + this->radius > GetScreenHeight() || this->y - this->radius < 0) this->ySpeed *= -1;

        this->x += xSpeed;
        this->y += this->ySpeed;
    }

    void Ball::Draw() const
    {
        DrawCircle(this->x, this->y, this->radius, WHITE);
    }

    float Ball::getY() const { return this->y; }

While the keen-eyed, or at least C++ fluent may know the issue immediately, it me took on the order of hours over a few days to find the issue. In this case, creating the header definition called `ball` in `ball.h` was taking priority over the argument `Ball ball` within the method `void CPUPaddle::Update(Ball ball)`. Upon changing the definition to `BALL_H`, as seems to align with the C++ style guide, the program did not run into compile errors and displayed the game in an incomplete state. Though I stopped it to write this before I investigated the current behavior of the game (See also, I have commented out other code that was cauing problems, likely also resolved by this change, to focus on this first).

### **7. Headers and Include Statements**

I am currently facing an issue that revolves around me not understanding how to use header files in small, multi-file projects. While I have seen tutorials cover the basics of C++ code, and the need for header files, I am yet to find out what 

### **8. C++ for a Java Dev**

https://blog.scottlogic.com/2021/04/22/losing-the-fear.html

I cannot help but get an incredibly stuck up vibe from this article, but would like to spend some time to try to take it at face value. Pointers have not been super necessary, references sound nice but don't seem necessary as I can pass things as usual (the CPUPaddle is moving as expected),


### **9. Arrays**

Arrays have caused me some trouble in C++ and intend to do some watching of videos to help smooth out the process. The below examples are the working examples only.

[Video 1](https://www.youtube.com/watch?v=1FVBeLD_FdE)

Simple Array Example:
```c++
/*This must be const with my compiler despite the video not declaring as such*/ const int x = 5;
int arr[x] = {1,2,3,4,5};
arr[0] = 10;
cout << arr[0] << endl;
cout << arr[7] << endl;
```

This first example is pretty straight forwards. We define an array of size 5 according to the variable `x` and initialize the set of values `{1,2,3,4,5}`. Then we access the value at index `0` and reassign it to the value `10` before printing the value. Line 5 of the above does generate a warning Visual Studio but does not crash or throw an error, inline with C++ lacking run-time out of bounds checking. Further, this will return garbage, as data fetched is not even necessarily being used by the program and isn't meaningful. Therefore, care must be taken to always access elements within an array's bounds (or not if you are trying to steal data).

Note:: The initializer line of the above does not actually need the `x` or `=`to compile, as the size can be infered/implied by the compiler based on the initialization. I am completely unable to determine how to use separate declaration and initialization lines for arrays in C++. And later information suggests that this is not possible in the manner I desired. Separate initialization of an array in C++ must either happen inline with the declaration or on separate lines for each individual values, you cannot assign multiple values in the same statement.

### **10. stl::vector**

At the time of writing these words, I have been told that it is often the case in C++ that a std::vector is the more appropriate structure for data in C++. I get the vibe that these are more similar to Java ArrayLists, but I really don't know.
[Video](https://www.youtube.com/watch?v=VNb3VLIu1PA&t=509s)
Understanding 1: I was at least partially wrong about by intuition (at least as far as I remember Java's AL<>). The stl::vector class defines a list that is stored in contiguous memory (the main thing that I believe is different in Java), is of a fixed size, but will resize itself to a more appropriate size when necessary. The 'contiguous memory' feature reduces the access time of elements.

To use a vector in C++ code, you must include the following lines in your soruce:
```c++
#include <vector>
using std::vector;
```
The second line is not strictly necessary, and may be considered bad practice by purists, but will speed up development as a newbie to the language.

Basic Use:
```c++
//Declaration
vector<int> ages;

//Initialization
ages.push_back(0);
for (int i = 1; i < 11; i++) ages.push_back(i);

//Easy Access (for printing)
for (int age : ages) cout << age << endl;
```
Declaration of a vector is pretty simple, and I suspect cannot (or it rarely makes sense to) include any initialization inline. 
Initialization can be done via the `push_back()` method. This adds an element to the currently last unused element in the vector. If the vector is full or close to full, the vector will expand itself in memory. I use the word can, as I suspect there are methods like `push_front()` or `push(<type>, int)` which allow for different assignments to locations in memory.
Access can be done very simply with the same for each syntax as Java. The `for (<type> name : vectorName)` is very handy, though does not allow for an innate index the way a loop on a normal array would. This issue can of course be sidestepped by declaring an index variable that gets incremented each iteration through the loop.

### **10.1 Iterators**

Iterators are handy tools to run over vectors (amoung other things probably) that ease the looping process. Some sample code can be found below.
```c++
// Declaration
vector<int> ages;

// Initialization
ages.push_back(0);
for (int i = 1; i < 11; i++) ages.push_back(i);

// Iterator
// Loop from the begin location of ages to the end location of ages, and increment the iterator each time through the loop.
// The auto keyword automatically determines the type that is necessary to ensure the code compiles.
// It determines this based on the return type of the call "ages.begin()".
for (auto it = ages.begin(); it != ages.end(); it++)
{
	// This does not compile, cannot print an iterator directly
	//cout << it << endl;
	// Other Options
	cout << *it << endl;  // Value in the array (0-10)
	cout << &it << endl;  // Location in memory of the iterator (doesn't change)
	cout << &*it << endl; // Location in memory of the value in the array (increments by 4 bytes)
}
```
Using the iterator is a little trickier than the Java equivalent. As the comments note, you cannot simply print the iterator `it` itself. But you can dereference the iterator to get the value by `*it`. This is generally the most useful of the three lines, but all are included for completeness.

IMPORTANT:: Constant Iterators.
The below code shows the above rewritten with constant iterators. A constant iterator disables the iterator from modifying the values of the collection being pointed to. This is helpful to avoid unintended changes to values in code that only needs to read values from a collection.
```c++
vector<int> ages;
ages.push_back(0);
for (int i = 1; i < 11; i++) ages.push_back(i);

// Constant Iterator
// These iterators only allow data to be read from the iterated collection, not modified
for (auto it = ages.cbegin(); it != ages.cend(); it++)
{
	// This does not compile, cannot modify a constant iterator
	//*it = 20;
    cout << *it << endl;  // Value in the array (0-10)
	cout << &it << endl;  // Location in memory of the iterator (doesn't change)
	cout << &*it << endl; // Location in memory of the value in the array (increments by 4 bytes)
}
```

OTHER::
Here are several other methods available for C++ vectors.
 - `size()` - The number of elements currently in the vector.
 - `max_size()` - The maximum possible number of elements in the vector (probably huge unless resized)
 - `capacity()` - The current number of elements the vector can contain before resizing
 - `resize(int)` - Forcefully resize the vector (can lose data)
 - `empty()` - Returns whether the vector is empty or not (size() == 0)
 - `[int]` - Access the element at the provided value
 - `at(int)` - Access the element at the provided value (identical to above)
 - `front()` - gets the element of the vector at index `0`.
 - `back()` - gets the element of the vector at the maximum used index/the maximum index of the vector
 - `clear()` - Sets the size of the vector to 0.

SPECIAL::
Insert, Erase, Pop:
```c++
vector<int> numbers;
for (int i = 1; i < 11; i++) numbers.push_back(i);

// This pushes the value 88 into the vector at index 5, while shifting all other elements to an index one greater.
numbers.insert(numbers.begin() + 5, 88);
// This shifts all elements after index 5 to an index one less.
numbers.erase(numbers.begin() + 5);
// The above lines would show only the numbers 1-10, as index 5 is being inserted and erased.

// This line removes the last element from the list.
numbers.pop_back();
```
These seem useful, if more situational. Despite what I suspected, there is not an explicit `pop_front()` method. Though this can be easily reproduced by using `.erase(vectorName.begin())`. IMPORTANT, you cannot specify by a simple numeric index, you must reference the beginning (or I assume ending) of the vector.

Understanding 2: After following along with the video, vectors are probably going to be my go to for most list applications. There will absolutely be times where an array or an enumeration is more appropriate, but the flexibility and ease of use of a vector is to great to pass up.

### *11 STRINGS!**

I have done a bit with strings in my initial experiments in QuickGraph, and realize that I really do not have a good handle on them. I initially had the first of the two below code snippets in my `Vertex.cpp ` file, and changing to the later fixed what appeared to be problems recognized by some very low level C++ language code for supporting strings.

```c++
int Vertex::assignText(string in)
{
    int max = in.size();
    int out = TEXT_ASSIGNED;
    if (max == 0)
    {
        this->assignNullText();
        return EMPTY_TEXT;
    }
    if (max > MAX_VERTEX_CHARS) out = TRUNCATED_CHARS;
    for (int i = 0; i < MAX_VERTEX_CHARS; i++) text[i] = in[i];
    // I did also try text[i] = in.at(i); but got a different very low level error.
    return out;
}
```
```c++
int Vertex::assignText(string in)
{
    int max = in.size();
    int out = TEXT_ASSIGNED;
    if (max == 0)
    {
        this->assignNullText();
        return EMPTY_TEXT;
    }
    if (max > MAX_VERTEX_CHARS) out = TRUNCATED_CHARS;
    const char* use = in.data();
    for (int i = 0; i < MAX_VERTEX_CHARS; i++)
    {
        text[i] = use[i];
    }
    return out;
}
```

At the time of writing I am really quite unsure about how I should be handling strings in C++. There is more I could say here, but I don't think it means very much, and will say only, I need to learn more.

### **12. Method Signitures**

I have discovered that C++ is quite strict (despite some seemingly unnecessary flexiblity) about its method signitures. Namely where the `const` keyword can be placed. As far as I have experimented, the `const` keyword can be placed immediately before or after the method name in the declaration. But, the keyword must then be in the same place in the implementation, the two keywords cannot be in different places. I am yet to try to place the keyword differently relative to other method keywords, as I am not fully awake yet and it is not massively important. 

### **13. What's the deal with & *?**

I realize that while I have a sense of the reference and pointer operators, I don't have nearly as good a handle on them as I should. So I intend to fix that. See the below samples to see what I have learned.

1. Reference Variables and Addressing:

The below makes pretty intuative sense given my limited experience with C++. The reference operator applied to the variable `beta` causes the variable to become an alias of the variable `alpha`. Where as the direct assignment of `delta` to `alpha` copies the value currently in `alpha`. Both of these functionalities are useful, but should not be allowed to mingle in my mind, as difficult as that may be.

In the case that a C++ compiler is not at hand, the output of all three unmodified variable console statements is 7. The output of the address of the variables `alpha` and `beta` are equal to each other, though will be different if the code is run repeatedly. The output of the address of the address of `delta` is necessarily different from that of `alpha` and `beta`, as `delta` contains a copy of the value of `alpha` at the time of `delta` being initialized. Though as one test reveals, the values are close together within memory without being adjascent to each other.

```c++
int alpha = 7;

int& beta = alpha;

int delta = alpha;

cout << "alpha: " << alpha << endl;
cout << "&alpha: " << &alpha << endl;

cout << "beta: " << beta << endl;
cout << "&beta: " << &beta << endl;

cout << "delta: " << delta << endl;
cout << "&delta: " << &delta << endl;
```

2. Pointers:

Pointers are related to aliases, but not the same. Where aliases allow multiple names to be given to the same data (calling my step brother Smurf instead of his acutal name). While pointers store a number which is the location in memory of the variable being considered. This principle is not complicated but using them correctly and effectively may be beyond the scope of what I can achieve at almost 5am.

The below code shows about what I expected. The value in `alpha` is the assigned `7`, and the address of `alpha` is accessible with the `&` operator. Further, the value in the variable `charlie` is equal to the address of `alpha`. And the address of `charlie` is different from the address of `alpha`.

```c++
int alpha = 7;

cout << "alpha: " << alpha << endl;
cout << "&alpha: " << &alpha << endl;

int* charlie = &alpha;

cout << "charlie: " << charlie << endl;
cout << "&charlie: " << &charlie << endl;
```

3. MOAR