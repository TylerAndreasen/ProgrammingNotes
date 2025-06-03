# Polyominos in Python

I am attempting to create a n-polyomino generator in Python. The following are notes I want to keep throughout the project.

## Notes

1. The following line will take in a NumPy `ndarray` object and add a layer of padding to all sides of the outer edge of the shape. This is not a universal solution, as there will be shapes that grow far more in their bounding box than necessary.

```python
a = np.pad(a, (1, 1), 'constant', constant_values=(0))
```

The above syntax implies that there is not easy control of adding padding to the "bottom" of the shape but not the "top". There does not appear to be native numpy code to create a 0-padding around shapes as I desired, but it was not a huge pain to implement.

I now have several methods and tests written, largely keystone's that underlie the algorithm as a whole. There are several more methods that will need to be stubbed, tested, and implemented before I can really take a stab at the main algorithm.


What, at a high level is the goal of this project?

Create a command-line program which calculates the number of unique polyominos possible with a supplied number of squares.
I don't intend to make this a highly feature rich program (many command line arguments for behavior config et cetera).
I intend for the program to read from files in the same directory as the source to attempt to bootstrap itself, which allows the program to be run, stopped, and re-started without losing all progress.
    I am unsure if I will try to save data about shapes periodically during generation to allow a user to stop the program while calculating a certain size shape, as I am unsure how the program at a later time would detect if the partially written file is complete. I could create a convention which says that when shapes are saved before the generation process is finished, that a empty 1x1 shape is added at the end, where a full 1x1 shape is added when the file is complete. This could work and means that checking the last item results in continuing from partially completed work. This is not a high priority issue.

What is the big picture algorithm?

Start:
    while getting user input loop:
        Ask User what value of n to use for shapes to generate.
        if n is non-numeric:
            ouput needs number
        elif n < 1:
            output needs valid number of squares
        # What is a plasible upper bound? How big of an array can numpy handle?
    # end while
    if n > 27
        output As of writing this program, humans have not calculated beyond 27 squares.
        output You are unlikely to reach the end of this program quickly.
    if n > 64
        output If you wish to know the answer to the number of shapes made with n squares,
        output You should likely not be running Python that you found on the internet
        output As the code will not be nearly effecient enough to complete in anything short of geologic time scales
        output on the hardware available to the original developer
        output The developer advises you to stop the program and find a more effecient menas of calculating.
        output If you continue, you have been warned, don't expect to see the final answer in your lifetime.
    if n is < 3:
        output there is only one shape with n squares
    else:
        initialize hard-coded 1x2 shape

        create set of small shapes
        add 1x2 to small shapes

        create set of large shape encodings

        do:
            for each shape in small shapes:
                create first novel encoding from shape

                if (first encoded novel shape is in the set of large shape encodings)
                    continue
                else # We know the first shape is not in the set, and could be legally added
                    create shell from shape
                    create set of novel shapes from shell and shape (skip first)
                    create set of encoded novel shapes set of novel shapes (skip first)
                    define add_flag = true
                    for each encoded novel shape after the first:
                        if encoded novel shape exists in set of large shape encodings
                            add_flag = false
                            break
                    if add_flag
                        add first encoded novel shape to set of large shape encodings
            # Generated all encodings for large shapes of size m.
            if m == n
                output that there are large shape encodings.size() polyominos of size n
                break
            else # m < n    # m will never be bigger than n by the logic of the program
                remove all elements from small shapes # How to do this
                for each encoding in large shape encodings
                    generate shape from encoding
                    add shape to set of all small shapes
                remove all elements from large shape encodings
                m++
        while (m < n)
    output Thank you for your work in recreational mathematics

                    
                            


