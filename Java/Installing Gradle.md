
I realized later that I did not take any meaningful notes on how to install gradle (on Windows) on a device and will add that here. For a video version see [this video](https://www.youtube.com/watch?v=R6Z-Sxb837I)

## Steps

0. Have an internet connection to the powered on device that you want to install Gradle on.
1. Ensure you have a version of Java after or including 8 (as Gradle only support Java 8 and later).
2. Download the most recent (or other desired) version of Gradle from gradle.org/releases
3. Extract the zip into a known place on your device.
4. From the contents of the zip, open the `bin` folder, and copy the address.
5. Open the Environment Variables menu via the start menu.
6. Add the copied address to the list of system path variables for the device.
7. Open a new Command Prompt or other CLI and run `gradlew -v` to check the extraction and path worked correctly, you should see the gradle version information for the version you have installed.