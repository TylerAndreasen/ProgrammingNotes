# Unix Command Line

Important Commands for the Ubuntu VM I am running in VirtualBox.

- ls : lists files and directory in the working directory
- pwd : prints the working directory
- cd sampletext : changes the working directory to the listed directory.
    literal values are assumed to be sub folders. multiple levels of directories can be navigated with `/` characters. the containing directory can be reached with `..`, and the listed escapes can be chained together.
- Ctrl+U ?? used to clear the current terminal output.
- explore . : opens a file explorer at the working directory (custom alias)
- cat : Short for concatenate, when provided one or more file name, the cat command will print the result of a file into the terminal. I often find that the echo command or another command that generates a lot of output with a ` > filename.txt` is more useful than seeing a file at the command line. Can be pointed into a file using ` > ` to copy one or more files into another location.
- code . : Opens VS Code in the current directory with all nested contents.