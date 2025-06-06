
There are a couple things to note about my install of Ant.

There are two path variables that must be set:
1. For the User: `%ANT_HOME%` must be set to the location of the extracted zip from Apache.
2. The User's Path variable must contain an entry which points to the `\bin` directory within the `ANT_HOME` location, but cannot depend on the location of the `ANT_HOME` value for some reason.