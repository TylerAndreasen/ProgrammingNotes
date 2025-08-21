# PyGame

I am starting a Snake implementation in Python using PyGame, and realize that I need to take my on notes on PyGame for my own reference.
Immediately, pygame feels very different from any other tool I have worked with, the following in a minimum script to get a PyGame window to remain open:

```python 
import pygame

pygame.init() # Starts PyGame

print("Hello PyGame")

window_width = 600
window_height = 400

# Gets reference to the system clock to scale events and value based on framerate
FramePerSec = pygame.time.Clock()

# Defines the size of the window
display_surface = pygame.display.set_mode((window_width, window_height))

pygame.display.set_caption("PyGame Window")

temp = input("Holding")
```

The implementation of a root window 'surface' object is strange to me, though it appears that any visual element (or perhaps element with a rectangular shape) is called a surface.