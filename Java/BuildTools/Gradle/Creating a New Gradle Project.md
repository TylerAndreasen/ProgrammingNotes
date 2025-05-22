# Creating a New Gradle Project

When working with Gradle, there are two ways to begin.
1. Importing an existing project (see `Importing Gradle Project.md`), or
2. Creating a new project from scratch.

The following aims to express simply the steps required to create a novel Gradle project, though comes with the assumption that Gradle is already installed on the device.

## Steps

Note: The below code snippets are Kotlin, which I believe requires open braces to be on the same line as the code that preceds them, unlike Java, which does not care where the braces are.

1. Open a new CLI and run `gradle -v`. This should report the current Gradle version on the device and confirms that the tools is ready to be used.
2. Navigate to the location you wish to create a new gradle project.
3. Run `gradle init`. This will create the necessary files for a new Gradle project. There are a number of responses needed for this command, my responses for them were [4, product, 1, no]. NOTE: I would advise that you back up any contents in the location you are creating the gradle project in before running this command. I had no issues with files being overwritten, but the command does state that files can be modified or overwritten, so proceed with caution.
4. Run `gradle tasks`. This should indicate that Gradle is working properly and lists all of the available Gradle tasks which can be performed. There are not many by default and they are not very useful to us at this time.
5. Open the `build.gradle.kts` file. After the default comment (which you can delete if you so choose), add the following block. This will add a number of java related tasks to the task list, and should include everything we will need for the project.

```java
plugins {
    java
}
```
6. Run the `gradle tasks` command again. This will reveal that several commands have been added to the list.
7. Write or locate your test code. Place this/these file(s) into a sub directory of the Gradle project. This subdirectory will need to begin `src\main\java` and be followed by something in the typical package naming convention. Locally, I built it as `src\main\java\com\textgameone\game`. The `game` directory will then be the top level domain for code files in the project, and resource or data files will go into `src\main\resources\`.
8. With code in the above location, run the command `gradlew compileJava` to compile `.java` files into `.class` files in the directory `build\classes\java\main\com\textgameone\game`.
9. When we have resource files as a part of the structure, run `gradlew processResources`. This will clone data into the directory `build\resources\main`.
10. Copy the following snippet into the `build.gradle.kts` file. This should specify a main class for the jar, and allow the jar to be run.

```java
tasks.named<Jar>("jar") {
    manifest {
        attributes["Main-Class"] = "com.textgameone.game.ExampleRunningClass"
    }
}
```

11. Run `gradlew jar` to create a jar file in the directory `build\libs`.