# Overview of Python

Python, as a scripting language, is fairly easy to use and write in, and this far the lack of type safety is yet to bite me. My first project relies on Numpy which was luckily pretty easy to install.

## Important Info

1. When using the command-line (at least using git bash on windows), to exit the interactive python terminal use Ctrl+C. This is the only way I have found to exit the interaction without killing the terminal entirely.

## Arrays and Multi-Dimensional Arrays

Arrays in Python can be defined in much the way they are defined in C-like languages accepting the type declaration. Here is a simple example:

```python
arr = [1,2,3,4,5]
words = ["I'm", "like", "a", "gay", "sea", "otter,", "I", "blow", "other", "dudes", "out", "of", "the", "water"] # Taken from Words, Words, Words, by Bo Burnham
```

There also exist more sophistocated ways of generating arrays, like the one below, which generates a 5 by 5 array of zeros*:

```python
arr_2d = [[0] * 5 ] * 5
```

*Except this doesn't really work, as the `* numeral` syntax just makes duplicate references to the same data, meaning that the 2d array from above will contain 5 copies of the same 5 element array. Strangely, the object will be the same between arrays, but not between all cells as I would have expected based on the description I just found [here](https://cs.stackexchange.com/questions/145799/python-assigning-values-to-2d-array-elements).

This syntax will actually generate an `[n][n]` array of the value 0 that is not a bunch of shallow copies.

```python
[[0 for _ in range(n)] for _i_ in range(n)]
```

Weak variable convensions aside, this does result in 2d arrays that can have n^2 unique values stored within. I ran into very strange problems with this array-wise duplication of data during my first attempt at building Minesweeper in Python.