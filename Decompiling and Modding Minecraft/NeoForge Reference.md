# NeoForge Reference

This document is a reference manual for things I have learned in NeoForge, focusing on little changes and set up preferences. Command line interactions will be stored in a separate document.

### 0. What is and is not updated just by running `gradlew runClient` and other commands?

It has quickly become clear that given the time that running commands like `gradlew clean` and `gradlew build` can take, I need a reference of things that can be viewed as changes with and without different commands. AFAIK, the `gradlew clean` is not strictly necessary as `gradlew build` should run it, but I am unsure.

1. Only Running `gradlew runClient`: After making a texture change (IE, making a change to the `.png` after the other components were correct), the changes were immediately visible. So the game can simply be rerun via `gradlew runClient` after a minor change. I suspect that this change also applies to other changes made to `resource` files, but I have not tested.

### 1. Mod Name and ID

Sensibly, I would like to name and identify my mod uniquely, and my current implementation seems to have an unfortunately poor system of managing this. Strangely, there appears to be no intended place to name or identify the mod in `build.gradle` or `settings.gradle`. The `neoforge.mods.toml` does present several lines related to mod settings management, including modId, version, Display name, and all sorts of other metadata that can be explored. However, it seems that I must also specify the mod Id in the Example Mod Class, and I am unsure how to load the value from the `neoforge.mods.toml` without simply pointing a file reader to the correct line.

After giving this a quick test, changing the class name Example mod to CanaTweaks, the process seems to be pretty straight forward (before running the client). So the mod name seems to have taken effect, as has the modID, though it appears that the description should be specified in the `gradle.properties` file to properly take effect.

### 2. Translation Tables

While I suspect it will be a huge pain, the use of translation tables will be a good learning experience for future development projects. In Gradle, the path for translation files is `ModWrapper/src/main/resources/assets/modId/lang` and file names are formatted as typical language codes. Translation keys are a tad tricky, as they seem to not quite have the format I expected, but booting the game should allow you to check which ones work, and replace any strings that don't function. I built the following English Translation table for the example mod. Looking at it later, the creative mode tab name translation string could be much clearer in origin, but seems to be moer flexible than the item or block names.

```json
{
    "cttab.canatweaks": "Cana Tweaks",
    "item.canatweaks.example_item": "Free Sample",
    "block.canatweaks.example_block": "Unpaintable"
}
```

### 3. Texture Issues

One of the most troublesome issues I have faced in the earlies stages of mod development is getting a texture to properly apply to an item, and I have learned for sure exactly one thing:
>   Ensure you are always saving an image file with the extension `.png`, not simply typing out the needed extension in the file name bar when saving via Paint.

This may seem like a super obvious, but resaving the first custom texture I created allowed the texture to display.

>   Editing textures is best done in GIMP (as it is a free tool that is much more powerful than MS Paint), namely allowing the user to create transparent images, though it will take more time to gain fluency with GIMP.

### 4. What is a Resource Location?

While I am lead to believe that a Resource Location is fairly straight forward in concept, there are potenially layers and implementation details I am not aware of yet.

A Resource Location seems to be an inline representation of some file in the `resources` directory of the game instance. This allows the game to look for modded (and presumably vanilla) data that does not make sense to modify or specify in code, including textures, models, translation strings, and possibly more. Building the resources for the first successful version of Free Sample was confusing to arrive at, but should be easy enough to replicate for items of equivalent complexity. However, more complex items (those with multiple states, textures, names, more) are likely to involve more careful management of resources, but such is life when trying to create more interesting and dynamic mechanics. 

https://docs.neoforged.net/docs/misc/resourcelocation
https://docs.neoforged.net/docs/items/



### 5. Creating a new item

It has been several days since I touched this project meaningfully and do not recall the details of what it takes to create a basic item, though I know there are a few things required.

0. Name: Items and Blocks must have a name attribute associated with them, this name is then used to reference the three following elements 
1. Texture: Best edited in GIMP, create a 16x16 image with a transparent background to create the texture. IMPORTANT: ensure that you are *exporting* as a `.png`. As using the basic *save* featuer of GIMP does not allow you to save as a `.png`.
2. Translated Name: In the translation file `en_us.txt`, ensure to add a line that matches the format of the other resource names with the display name desired.
3. Model File: Each item must also have a model file associated with it. While I am starting out, there is nothing wrong with copy-pasting the one model file I have for each item.
4. Updating Code: There will be one if not a few places I will need to add code to ensure that the resource files can be properly applied in game. I will need to create a new Item in the mod's config class, assign it certain properties, and a resource location (to point to the files created previously).

Note: For my example mod, I place the code for my own items in a folder in the `main/java/.../canatweaks/items`. This is to split off functionality and purpose. This may become more of a detriment than a benefit depending on how more complex interactions with blocks and items become, but feels prudent for now to avoid a single config enourmous class.

### THE END