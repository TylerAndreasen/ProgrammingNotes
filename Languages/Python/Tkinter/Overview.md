# Tkinter

Tkinter, TKinter, T-Kinter, Kinter, what ever you call it, is a fairly simple UI libarary for Python, though there are many alternatives, this is the one I have started with. (In truth I did not put a ton of time into making said decision, as I intend to learn what I do and don't like about Tkinter, and may decide that another toold which addresses those issues will be my used library.)

As with any UI toolkit there are many featrues made available, called Widgets, that have a huge range of functionality.
Note: I have either not found or will never find a dedicated vertical list manager type widget. I inteded to place a collection of MineSweeper buttons into a grid, and put the wrapper into the first of a two slot vertical manager, and use the second as the UI for restarting levels, mine counter, game size indicator and the like. I know there is a Menu widget, that would create a Menu Ribbon for a Program, but I never found a similar widget for vertical management.

## Specific Widgets

### 1. RadioButton

The following is a display of Radio Buttons, which typically appear in a list, and only one can be selected as an option.

```python
# From https://coderslegacy.com/python/list-of-tkinter-widgets/
from tkinter import *
 
root = Tk()
root.geometry("200x150")
frame = Frame(root)
frame.pack()
 
Var1 = StringVar()
 
RBttn = Radiobutton(frame, text = "Option1", variable = Var1,
                    value = 1)
RBttn.pack(padx = 5, pady = 5)
 
RBttn2 = Radiobutton(frame, text = "Option2", variable = Var1,
                     value = 2)
RBttn2.pack(padx = 5, pady = 5)
 
root.mainloop()
```

Note that the field parameter `value` does not seem to have any effect on the RadioButtons, and as written, both RadioButtons appear as selected when they are created. I found a claim online that said this could be fixed by setting the `value` or `tristatevalue` fields, but with probably not enough testing, I could only ever have all or none-initally selected.

### 2. Text

As of writing, I am in the early stages of building my own text editor in Python, and the Text Widget will be a vital component.
Luckily, a number of the features that I want in a Text Field already exist (Selection with the Shift key, Copy, Cut and Paste hotkeys, capitalization changes based on the CapsLock and Shift keys). Though not everything I would like is present, namely deleting entire words when Control is held and Delete or Backspace is pressed.
The following code was the basis that I implemented to get a text entry working.

```python
from tkinter import *

root = Tk()

textbox = Text(root, width=10, height=10)
textbox.grid(row=0,column=0)

root.mainloop()
```

Note that the Width and Height parameters define the number of characters and lines in the default, monospaced font used by the Entry, and linewrapping is a default, though I do not know if this is a modifiable feature. If the total text in an entry exceedes the number of lines present, and the text cursor attempts to reach (or type) another character, the entry will shift text up to show the next line, and will go up if the cursor is raised or characters are Backspace'd.