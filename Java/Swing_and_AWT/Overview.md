# Java Graphics Overview

Modern Graphics in Java is built using the Swing and AWT frameworks. The exact differences between them and what functionality falls into which is not massively relevant to me, as I import elements from both as I am building things.
But they do implement a pretty consistent structure of how graphics elements are built.

If you have never worked with or don't have extensive experience with Swing and AWT to closely follow some tutorial and or use an IDE that will automatically manages imports and will insert code when abstract code needs to be implemented.

### Overview

In order to have graphics appear, there are a few things that must be done and some style convensions I intend to follow.

SA (Swing and AWT) allow developers to create windows on screen with the `JFrame` class. This acts to create the size of the window (min 100x100 on MS Windows versions), with a boarder and implied buttons.

In order to put smaller frames (rectangles that store other things) into the primary frame, I think they can be specified directly, but it is better to use some `LayoutManager`.
`LayoutManager`s come in several flavors that have different behaviors; aligning all added elements into a row, and dropping to the next row when the maximum width is reached, separating itself into four cardinal edge regions and a center region, and more.

When elements then need to be added to the primary (or any) frame, additional information is supplied to specify where in the `LayoutManager` the element goes.


In order to really grapple with SA, you need to understand the MVC design pattern.

One of the quickly useable interactable elements of SA is the `JButton` class which creates a simple button when added to some `LayoutManager`. On its own, the `JButton` object doesn't do anything on its own, an `ActionListener` must be added to it.
`ActionListener`s are objects that are associated with interactable elements like buttons that execute code when the element is interacted with. Data can be extracted from the `ActionEvent` parameter of the `actionPerformed` method that is defined within the `ActionListener` (See the code snippet at the bottom of this document). Inside of this `actionPerformed` method, pretty much any code can be written and executed (though I should note that the `this` keyword then refers to the `ActionListener` object, not the object of the class that the `AL` is defined within).


One concept that I do not have answers on is how I implement a wrappers for multiple SA objects. Another is how I dynamically add elements to a list.