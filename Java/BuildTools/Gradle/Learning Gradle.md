# Learning Gradle

In previous years, I have tried to learn how to build Minecraft mods 'all at once', but made very little progress due to a combination of having many tools and ideas thrown at me at once, and not taking notes about what I did and what problems I encountered. I intend this document to be a comprehensive guide to Gradle for myself, listing high level concepts, then the steps for building a project, then discussing issues I ran into.

### Contents

1. Big Ideas
2. Starting a New (Simple/One-Build) Gradle Project
3. Issues and Resolusions

### 1. Big Ideas

Gradle itself is a build management and automation tool. This means that Gradle is built to automatically complete a variety of meta level tasks for code projects (with the notable exception of version control as it seems), managing source code and resource files, compiling Java files into class files/a jar file.

When a Gradle project is created (either from scratch or inside an existing code base), several items are created. 
    The first is a `.gradle` directory, which contains a large amount of meta information about how gradle operates internally and will not be explored in great depth here.
    The second is a `build.gradle.kts` and `settings.gradle.kts` files.
        `build.gradle.kts`: Configuration for the build process that Gradle will undergo, the `build.gradle.kts` specifies dependent libraries to be packaged along with the local source code, meta data associated with the project at hand (group, version, and more).
        `settings.gradle.kts`: Configuration for gradle plugins being used in the build process and the project name (the former seems to be one of the issues I am facing at the time of writing).

Task: An executable unit of work that gradle is capable of performing. A list of all available Gradle tasks can be access by `> gradlew tasks` (the leading `./` seems to be a Unix exclusive). Tasks can also be dependencies of other Tasks. While I am led to believe that Eclipse can run tasks internally, I suspect I will want to always run them from the command line as GUI programs seem to have problems correctly running command line tasks.

Wrapper: A command line interface for working with Gradle, which should be commited to version control. The wrapper is what allows a developer to run tasks including building a project with the `gradlew.bat build` command.

Project Structures: Gradle supports single- and multi-build projects. The difference between the two is that the multi-build projects break their output (usually larger and in multiple distinct parts) into multiple builds which can be tested or even distributed separately (ex. I am building a mod and an optional addon mod, so they are developed together in tandem, but not tied together on build). Single-build project, sensibly, only create one build when run. 

Main Attribute: One of the surprises of [this video](https://www.youtube.com/watch?v=R6Z-Sxb837I) was the explicit definition of the main class in the 