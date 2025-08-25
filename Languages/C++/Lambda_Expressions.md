# C++ Lambda Expressions

Lambda expressions in programming languages allow programmers to encapsulate small bits of code to be run anonymously or passed as an argument to other functions. They can be very powerful, but can also be very confusing and hard to actually implement. This document will serve as storage for things I learn over time.

Note:: I ran into a strange momentary issue with the `<function>` and `<vector>` include and using declarations, where placing the respective function statements before the vector statements caused a compiler error that disappeared after changing the order, but did not reappear when I reverted the order. Potentially an oddity with Visual Studio rather than C++.

Basic information on Lambdas can be found in `CPP.md > 15. Lambda Expressions`.

Assume for all following snippets that the following inports are used, as they are required to get the most basic implementations working:

```c++
#include <iostream>
#include <functional>
using std::cout;
using std::function;
```

The following code snippet compiles and runs without issue. I include this example to demonstrate to myself that even if no method is defined within scope that matches the signature, the code will compile, though of course cannot execute any lambda.

```c++
void callsLambda(function<void()> callable)
{
    callable();
}
int main()
{
    std::cout << "Hello World!\n";
}
```

So does this snippet: (Note the potentially required indentation of the body of the lambda.)
```c++
void callsLambda(function<void()> callable)
{
    callable();
}

auto callMe = []()
    {
        cout << "Hello World!\n";
    };

int main()
{
    std::cout << "Hello World!\n";
}
```

Swapping to using the lambda method compiles and outputs identically:

```c++
void callsLambda(function<void()> callable)
{
    callable();
}

auto callMe = []()
    {
        cout << "Hello World!\n";
    };

int main()
{
    callsLambda(callMe);
    //std::cout << "Hello World!\n";
}
```

(I tried to add parameters and got very lost.)
The following snippet implements a looping hello world statement in a lambda inside of main(), which captures a variable by value, and outputs as expected.

```c++
int main()
{
    int times = 5; // Number of times to print
    auto printHello = [times]() {
        for (int i = 0; i < times; i++) {
            cout << "Hello World!" << endl;
        }
        };
    printHello(); // Call the lambda function
    return 0;
}
```

For completeness, I include the following *non-compiling* snippet to remind the reader that captures can only reference variables in available in their scope. Both instances of the identifier `times` in the lambda `printHello` are unidentified:

```c++
auto printHello = [times]() {
    for (int i = 0; i < times; i++) {
        cout << "Hello World!" << endl;
    }
    };

int main()
{
    int times = 5; // Number of times to print

    printHello(); // Call the lambda function
    return 0;
}
```

To solve this, simply move the `times` token from the capture list, to the parameter list, AND ADD THE TYPE, and add the original variable to the lambda call, and the code compiles and runs as expected again (though is not meaningfully different than a normal function):

```c++
auto printHello = [](int times) {
    for (int i = 0; i < times; i++) {
        cout << "Hello World!" << endl;
    }
    };

int main()
{
    int times = 5; // Number of times to print

    printHello(times); // Call the lambda function
    return 0;
}
```

The next step in this process is to understand passing a lambda to another function, as in the following *non-functional* snippet:

```c++
void callsLambda(function<int()> callable)
{
    callable();
}

auto callMe = [](int repeats)
    {
        for (int i = 0; i < repeats; i++)
        {
            cout << "Hello World!\n";
        }
    };

int main()
{
    callsLambda(callMe(3));
    //std::cout << "Hello World!\n";
	  return 0;
}
```

In the above snippet, calling the function `callMe` inside of the `main` results in a `E0415` error. This indicates that there is no type convertion from `void` to `std::function<void ()>`. 

After stepping away, I found [this](https://stackoverflow.com/questions/40844622/use-a-lambda-as-a-parameter-for-a-c-function) SO question and the (currently) 3rd rated answer supplied this code. This feels far more understandable to me, and implies that I don't really even need to use lambdas as such for my current goal.

```c++
int SimpleFunc(int x) { return x + 100; }
int UsingFunc(int x, int(*ptr)(int)) { return ptr(x); }
auto lambda = [](int jo) { return jo + 10; };

int main() {
    std::cout << "Simple function passed by a pointer: " << UsingFunc(5, SimpleFunc) << std::endl;
    std::cout << "Lambda function passed by a pointer: " << UsingFunc(5, lambda) << std::endl;

}
```

The previous snippet and a bit of poking lead me to create the following snippet, which compiles and executes as expected. The one thing I should note is that I am returning a value, which while not always necessary, seems to simplify the implementation of passing functions around.

```c++
void callsFunction(int passIn, int(*callable)(int))
{
    callable(passIn);
}

int callMe(int repeats)
{
    //int repeats = 3;
    for (int i = 0; i < repeats; i++)
    {
        cout << "Hello World!\n";
    }
    return repeats;
};

int main()
{
    callsFunction(3, callMe);
    //std::cout << "Hello World!\n";
    return 0;
}
```