# JUnit Overview

After some fighting today I have come to understand how importing libraries in low level Java works with JUnit as the example.

In this case, I have all related files in a folder called JavaSquares (working with representing shapes, not important here). In the `/lib` subfolder I have a standalone jar called `junit-platform-console-standalone-1.7.0.jar` from JUnit via Maven Central. Source code is in `src/java` and test code is in `src/test` Regardless of how Ant interacts with this system, VS Code now recognizes a JUnit Jupiter import in those files. And on checking it, my current ant configuration is incorrect to know where JUnit is.