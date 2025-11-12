# The Command Line and Arguments Therefrom

**IMPORTANT**
This process can be made much easier by using the `argpars` library. Look into this.


Simply put running the following command in a terminal (assuming python is installed and the terminal is in the location storing the named file) will run the named Python source file:
```cli
python example_python_file.py
```

## Arguments

When running a Python script from a command line, all subsequent tokens (including the name of the script to run) is available via the idiom `sys.argv` assuming you `import sys` before hand. This list can easily be printed and used to do typical command line style interactions.