# NeoForge Reference

This document is a reference manual for things I have learned in NeoForge, focusing on little changes and set up preferences. Command line interactions will be stored in a separate document.

### 0. What is and is not update just by running `gradlew runClient` and other commands?

It has quickly become clear that given the time that running commands like `gradlew clean` and `gradlew build` can take, I need a reference of things that can be viewed as changes with and without different commands. AFAIK, the `gradlew clean` is not strictly necessary as `gradlew build` should run it, but I am unsure.

1. Only Running `gradlew runClient`: After making a texture change (IE putting data into the blank texture file), no change was visible. I realize also that I may need to associate the texture with the item explicitly.

### 1. Mod Name and ID

Sensibly, I would like to name and identify my mod uniquely, and my current implementation seems to have an unfortunately poor system of managing this. Strangely, there appears to be no intended place to name or identify the mod in `build.gradle` or `settings.gradle`. The `neoforge.mods.toml` does present several lines related to mod settings management, including modId, version, Display name, and all sorts of other metadata that can be explored. However, it seems that I must also specify the mod Id in the Example Mod Class, and I am unsure how to load the value from the `neoforge.mods.toml` without simply pointing a file reader to the correct line.

After giving this a quick test, changing the class name Example mod to CanaTweaks, the process seems to be pretty straight forward (before running the client). So the mod name seems to have taken effect, as has the modID, though it appears that the description should be specified in the `gradle.properties` file to properly take effect.

### 2. Translation Tables

While I suspect it will be a huge pain, the use of translation tables will be a good learning experience for future development projects. In Gradle, the path for translation files is `ModWrapper/src/main/resources/assets/modId/lang` and file names are formatted as typical language codes. Translation keys are a tad tricky, as they seem to not quite have the format I expected, but booting the game should allow you to check which ones work, and replace any strings that don't function. I built the following English Translation table for the example mod 

```json
{
    "cttab.canatweaks": "Cana Tweaks",
    "item.canatweaks.example_item": "Free Sample",
    "block.canatweaks.example_block": "Unpaintable"
}
```

### 3. What is a Resource Location?

https://docs.neoforged.net/docs/misc/resourcelocation
https://docs.neoforged.net/docs/items/


### THE END