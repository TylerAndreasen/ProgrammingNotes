# Importing Gradle Project

Before I can use Gradle as a part of a big project, I need to begin with a template. This document expresses how to import and implement a template Gradle Project.

My end goal is to implement a Minecraft Mod, so I will be using the NeoForge-Gradle Template, which I have already downloaded.

1. In the Project Explorer of Eclipse, Right-Click and select Import.
2. From the resulting menu, select `Existing Gradle Project`, then select `Next` twice.
3. Navigate to the file location of the template to assign the Project Root.
3.1. [This video](https://www.youtube.com/watch?v=ZYuwWwIhFWo) states that you may want to specify locations of Gradle and Java in the advanced options, which I do not plan on doing, as Eclipse seems to know what is doing when setting/finding these things.
4. Select `Finish`.
5. Now, the imported project should now exist in your Project Explorer.
    Unfortunately, I knew to do all of these steps, but it is good to know that I did not miss anything major during the import.


I found a longer intro to gradle video.

Important Files:
Despite what I originally  realized during a overview of a project section that my instance seems to be missing important files: build.gradle.kts, settings.gradle.kts


`gradle init`: Can be run to create (or hopefully finish) all necessary files to create a Gradle Project, but has many options I will want to note.
`./gradlew tasks`: Command run to list the currently available tasks. Just created projects will have very few tasks as the project contains little information.

Sensibly, as I had not installed gradle, the init command did not exist. It took me longer than it should have to attempt to reopen a new terminal to let path environment variables take effect in the terminal, which resolved the lack of gradle command recognition.