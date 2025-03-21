# Raylib: Advanced

I have built some fluency with raylib ove the last couple weeks and now want to build something a little more advanced. But I realize that a number of things that I could implement in C++ may be present within raylib already, and this is the space I have set aside to write down what I have learned about these more advanced topics within raylib.

For an upcoming project, I know I will want splines, static UI buttons, interactable UI elements that the user can {create, edit, destroy}, with different behavior based on a state within a MouseManager class, text entry from the user, and more. Having a peak at raylib 5 (which I may or may not have installed), I know that splines are already implemented. I believe I have seen UI as a package of raylib listed, and I can only assume that a graphics context such as raylib would implement a text entry itself. 

1. Splines - Use the `rshapes` package. Further reading needed to determine how to use beyond this.
2. GUI - Use the `raygui` package, the description is a little odd to me, and will require some reading to make sure that I am understanding the purpose of the package.

The above are only sourced from the [raylib 5.0](https://github.com/raysan5/raylib/releases) release, and text entry could very well exist and just isn't talked about there.

3. TextBox - A TextBox class is supplied within the `raygui` header. Some of the examples I saw while trying to find confirmation of this were a little scary, using a number of `#ifndef SOMETHING_OR_OTHER` statements. I am unsure if I am going to need to implement something like this for my projects that use the `raygui` package.

Upon looking at [raysan5](https://github.com/raysan5)'s GitHub, I realize there are quite a lot of packages, a number of which seem to be built with the purpose of helping you to properly prepare your source code and data files for distribution and even Steam Integration, wild and wounderful. 