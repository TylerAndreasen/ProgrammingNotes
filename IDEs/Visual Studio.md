# Visual Studio

I have, of course run into issues with software when I am first starting out with it and intend to write down the things I learn so that I don't forget it.

TODO Link to Raylib and VS exmaple code in 1.

### **1. Adding Files to Solutions**

While starting out with RayLib, I copied the files from "Programming with Nick" to get started. Unfortunately Visual Studio did not like the way I went about it.

Lessons:
1. Source Files do seem to appear in the Project folder. I am yet to find an easy way to do this. My current workflow is to use the UI to open the file in notepad, use the menu to save as, and then copy the file location to get the actual source location.
2. Simply dragging and dropping files from a folder to the editor will open the files but does not clone those files into the project. It seems that you must go to the Project folder, clone all of the files there, and then use the RClick > Add > Existing Items option when clicking on the Source Files Folder in VS to actually add the files. Not a great solution, but workable.

### **2. File Run from and Build Behaviors**

After a couple different phases, I have come to understand a quirk of Visual Studio that will take some adjustment to. After making changes to soruces files and running them, some changes to literal values were not being reflected in execution, the speed of a moving ball or the size of a rectangle. After a bit of poking, I found that compilation and execution of code through Visual Studio are different endeavors, and the latter does not automatically complete the former, as would occur in Eclipse or IntelliJ for Java. In short, it is my intent to build the habit of compiling (Ctrl+F7) before running (F5).

A similar annoyance is that the Build command is seemingly completely ignored unless I have the file with main() open. I find this quite annoying to need to move back and forth, and would like to find out how to change the environment to make this no longer required.
Despite what I would have thought, both the above behavior exists, and the environment does not allow me to have multiple main() methods within separate class files, and run the appropriate main() based on the file that is open. While there is little need of the following during project building, while I am learning C++, I would so very greatly benefit from some method by which to only compile and run a single class file at a time without needing to repeatedly comment an entire file, recompile, and rerun only to find I need to comment out another entire file that is causing trouble for the compiler, linker, or whatever.



### **3. Line Numbers**

I am finding it surprisingly annoying to not have line numbers in Visual Studio. I would not think this little feature would be so impactful. This can be changed via Tools > Options > Text Editor > General, and checking the Line Numbers box. (On my desktop installation, and possibly laptop installation, this setting showed as on by default but was not reflected in the editor.)