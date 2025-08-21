# TOODOO

I intend to create a bash script that will act as a command line todo list manager.
Primary interactions with the tool will look something like this (subject to change, especially as I understand bash scripting better).

```bash
$ toodoo list

# 1. Email Alana Waterman about tuesday meeting
# 2. Add test to model_test.py that determines if cells were assigned neighbor counts after being made mines themselves.
# 3. Push new feature of TOODOO to experimental

$ toodoo --detail 2

# Importance Category:  2 
# Created:              2025.06.28 22.34.25.369
# Last Edited:          2025.06.28 22.34.25.369
# Completed:            False
# Note: Add test to model_test.py that determines if cells were assigned neighb
# or counts after being made mines themselves.

$ toodoo --modes

# Importance Mode: Low
#   The order in which to show listed todos: Low/Early, High/Late
# Indexing: Number
#   The values used when specifying the rank of each todo: Number, Letter, NATO
# Intra-Importance Ordering: Long
#   Determinate of order of todos with the same length: Long, Short, Recent, Early

$ toodoo create "Eat Lunch"

X   No importance specified, please supply this information or assign a default importance for unspecified toodoos

$ toodoo create "Eat Lunch" 2

$ toodoo list

# 1. Email Alana Waterman about tuesday meeting
# 2. Add test to model_test.py that determines if cells were assigned neighbor counts after being made mines themselves.
# 2. Eat Lunch
# 3. Push new feature of TOODOO to experimental

$ toodoo complete 1

# Marked Todo Completed:
# Email Alana Waterman about tuesday meeting

```

Ultimately, this tool is a little silly, as outside task trackers can be used to store many tasks that need to be completed across projects, devices, life domains, and even people.
But I do believe there is value in such a tool. Namely in the tracking of things that need to be done for a project that must be picked up and put down, and left for extended periods (I know I have a number of side projects that have been abandoned because I did not understand my specific goal days or weeks later).

Further, this can be used to quickly note a half completed change, an inspired thought that could not be acted upon, or a (potentially very disheartening) realization of structural failure *without changing source files*. Not creating version history information in source files becomes a very handy tool when working in a (collaborative) context in which stray comments are problematic for some reason.