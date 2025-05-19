# Polycubes: Idea and Notes

I recently rewatched [this](https://www.youtube.com/watch?v=g9n0a0644B4) video which discusses Polycubes, and I became interested in taking a crack at trying to build a system to create polycubes.
From scratch, I know there are a number of difficulties with trying to achieve something here. The biggest is that this is a non-trivial problem for a human to solve, and trying to get a computer to solve it will likely be even harder.
One difficulty is the fact that a shape may be generated and already exist in some other rotation or reflection within the list of known shapes of the given size.
Another is encoding the idea of a poly cube in an effecient way. To save memory space, it may be worth while to trim the representation to fit, but this takes time, and depending on the language and implementation used to write it, may not be meaningful. (If defining byte arrays in something like C, trimming a shape with n = 5 down within a 8^3 byte array does not do anything.) This does then bring up the idea of creating a system which stores a linked list of bytes that are associated with dimension information such that a shape can be represented in as few bytes as possible. A 3x3x2 would require only 2 bytes, but notably more complex indexing logic based on the low size. Maybe this is worthwhile, maybe not.

# Resources

Alongside the link above, what follows is a list of resources I found while researching and working on this project.
[A](https://www.youtube.com/watch?v=g9n0a0644B4) - The original video that sparked my curiosity.
[B](https://www.youtube.com/watch?v=K9anz4aB0S0) - A video on CUDA, which I have tentative plans to implement a full version with.
[C](https://github.com/mikepound/cubes/blob/main/cubes.py) - The Python example created by Dr. Mike Pound in video A.
[D](https://github.com/noelle-crawfish/Enumerating-Polycubes) - A Mathematica example of creating these shapes and visualizing them.

## Notes

0. Generaly, I think it simpliest for small examples to use an list structure of byes, each bit of which defining the state of one cube, to be the simpliest live encoding of a polycube. This sort of encoding means that (if used) array operations and byte operations can be done quickly and easily across shapes. Further, iterating over the list in different ways allows the developer to artificially reflect, rotate, and possibly both, any shape to create encodings, without needing to store redundant copies in memory.
1. While writing the initial plan, I arbitrarily decided that the 0,0,0 cell of the polycube would be the bottom, front, right corner. I realized as I wrote this that there is a stark benefit to doing this. When bit shifting cubes left and right, a left shift (byte << 1 ) has left pointing arrows, and the reverse for right. While reversing the encoding and using the opposite arrows would not be a massively difficult challenge to overcome, it does make part of the problem more intuitive. The one downside is that I want the bottom sheet of the 8^3 to be the first set of bytes instead of the front which means that the byte[][] defines x as the position of a bit within the byte, and the array indices as byte[z] [y]. This does break from typical 3-D graphics convention, and I may change this later, but I think will be a standard to stick to until I find a reason not to.
2. I will likely be taking advantage of minecraft's ease of use to create the examples of shapes such that I can verify their correctness without relying solely on my mind.
3. Having no practical knowledge of CUDA or how to use it, I am unsure if it will be the language to use, though I suspect it's use on GPUs will mean that it handle parallel processing well, and work well with matricies, which my byte arrays basically are.

## Some Thoughts

The section Initial Plan (See Below) is a highly theoretical psuedo-code implementation, with the important caveat that most every action above array operations, byte rotations and the like must be implemented by me. This is one way to ensure (in)effecidency in the codebase, as I can test it and make modifications to the operations as needed. This however requires far more work on my part to implement. The implementation in Link A relies on the flexibility of Python and the library NumPy to make the calculations faster. This led me to realize that I need to spend more time now deciding on a language to use for the project, as I seem to be more than capable of reasoning through the functionality needed. But there are languages which will implement some of the low level functionality that I need, though I intend to use something natively faster than Python.

My initial thought is CUDA, a language created to interface with NVidia GPUs, of which I have one that would be rather useful to utilitize in this project. Beyond the speed and multi-thread capabilities of the language, I don't know much about it, most importantly how to write and compile code in it. Assuming that I am able to, what specific things will I need to know how to do: \/. I know that inevitably I will need to learn more about writing in CUDA than I have expressed, but these will be a good starting point. I should also note the importance of starting small. I will need to write several smaller programs which do simpler things before I will really be ready to tackle this. Beyond Hello World and other basic tests of the languages core features, I should benefit from implementing a 2-D equivalent of this process, as the logic will be of similar structure, but not as advanced given the drop of a represented dimension.
1. Hello World
2. Create variable
3. Create Byte
4. Create Byte array
5. Create Mutli-Dimensional Arrays
6. Bit shifting operations
7. Copying and Reassigning Variables
8. Matrix operations
9. Conditionals and Loops

## Initial Plan
Before doing a ton of research, I thought I would express some general thoughts as to how I might go about this.

Note: I do plan to start with a 2-D example in Java just to flex my muscles with this sort of idea first.
Note: Generally, I think it is better to transform the shapes only when strictly necessary, as this will always be an expensive operation.

Encodings: There will need to be two encodings for operating on these polycubes.
The first is a matrix style encoding, which defines a list of 64 bytes, where a 1 in a given bit means there is a cube in that position.
The second is a more compact list. Video A defines a potential encoding which specifies the size of the shape and positive and negative numbers for filled and unfilled cells. I want to iterate on this, though I don't have specific ideas at this time.

```
Psuedo:
    Accept as a command line param or config file value the maximum n to generate polycubes of .
    If maximum is 1 || 2,
        return 1.
    if the maximum if >=7 
        Warn user that the implementation does not support polycubes of n > 6 at this time.
        reduce maximum to 6

    Define list of encoded_shapes_n, encoded_shapes_n_minus_one, current operating shape, current shell, 
    define current_n = 2

    Check existing files for a cube file of sizes starting at the input value decrementing to three.
    if file exists
        load file of largest value.
        update current_n to largest value.
    if no file exists
        load predefined n = 2 example shape into the encoded_shapes_n_minus_one.
        define the encoded_shapes_n, and current operating shape to be empty
        define current shell to be empty
    
    Generating Loop:
    While (current_n < maximum) {
        While (encoded_shapes_n_minus_one is not empty) {
            current operating shape = get first from encoded_shapes_n_minus_one
            Pad( current operating shape )
        }
        current_n++;
    }


Pad (shape)
    // Ensure that no cube on the very outer edge of the shape exists within the current poly cube
    // Note: limiting the maximum value of n to 6 ensures that there is never a situation in which a polycube to be expanded already necessarily touches one face of the bounding 8^3.
    // Note: Moving past this size of 6 is non-trivial depending on language and implementation, though depending on that implementation, implementing going to successively larger sizes could be solved at once.
    
    // Top / Bottom
    Iterate over the bottom face,
        if any byte is not zero, // Note: The n < 7 limitation means that the top face will not contain any cells if the bottom does.
            mark that the shape needs to move up.
            break
    if the shape doesn't need to move up
        Iterate over the top face
            if any byte is not zero
                mark that the shape needs to move down
                break
    
    // Front / Back
    Iterate over the front face (ignoring the first and last bytes, checked by the top & bottom)
        if any byte is not zero
            mark that the shape needs to move backwards
            break
    If the shape does not need to move backwards
        Iterate over the rear face (ignoring the first and last bytes, checked by the top & bottom)
            if any byte is not zero
                mark that the shape needs to move forwards
                break

    // Left / Right
    // Note: These faces will be more complicated to iterate over, as we cannot simply index bytes

    // Right & Left
    For all bytes after the bottom sheet and before the top sheet (0 or 7)
        if the byte is not in the front or back sheets (0 or 7)
            if units bit is 1
                mark that the shape needs to move left
                break
            else if the bit[7] is 1
                mark that the shape needs to move right break
    
    If the shape does not need to move on any axis
        return the input shape
    else: named_block {
        t_shape is empty shape
        if the shape needs to move left/right {
            if needs to move left 
                for each byte in t_shape
                    byte = shape.byte << 1
            else 
                for each byte in t_shape
                    byte = shape.byte >> 1
            shape = t_shape
        }
        if shape does not need to move up/down/forwards/backwards
            break named_block
        t_shape is empty shape
        define a = 0, b = 0 // TODO collapse to ternary operations
        if up
            a = 1
        else if down
            a = -1
        if forwards
            b = 1
        else if backwards
            b = -1
        for t_shape byte[] 1..6, i
            for t_shape byte[i] 1..6, j
                t_shape byte[i][j] = shape byte[i+b][j+a]
        shape = t_shape
                
    }
    return shape
```