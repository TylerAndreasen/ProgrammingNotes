# NeoForge Reference

This document is a reference manual for things I have learned in NeoForge, focusing on little changes and set up preferences. Command line interactions will be stored in a separate document.

### 0. What is and is not updated just by running `gradlew runClient` and other commands?

It has quickly become clear that given the time that running commands like `gradlew clean` and `gradlew build` can take, I need a reference of things that can be viewed as changes with and without different commands. AFAIK, the `gradlew clean` is not strictly necessary as `gradlew build` should run it, but I am unsure.

1. Only Running `gradlew runClient`: After making a texture change (IE, making a change to the `.png` after the other components were correct), the changes were immediately visible. So the game can simply be rerun via `gradlew runClient` after a minor change. I suspect that this change also applies to other changes made to any `resource` files, but I have not tested.

2. Setting aside an issue with not exporting with GIMP properly, I discovered that adding Food related properties to my free sample item and running only `gradlew runClient`, the effects of the code were seen immediately upon running. This tells me that I should be able to modify any code in my code base, and then test it only by running the client. In order to create a Jar which is distributable, there is almost certainly a distinct set of actions, but I am not yet concerned about distribution at this time.

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
1. Texture: Best edited in GIMP, create a 16x16 image with a transparent background to create the texture. IMPORTANT: ensure that you are *exporting* as a `.png`. As using the basic *save* feature of GIMP does not allow you to save as a `.png`.
2. Translated Name: In the translation file `en_us.txt`, ensure to add a line that matches the format of the other resource names with the desired display name.
3. Model File: Each item must also have a model file associated with it. While I am starting out, there is nothing wrong with copy-pasting the one model file I have for each item.
4. Updating Code: There will be one if not a few places I will need to add code to ensure that the resource files can be properly applied in game. I will need to create a new Item in the mod's content class, assign it certain properties, and a resource location (to point to the files created previously).
5. Adding to Creative Tab: In order to test functionality and textures, the blocks and items added should be available through a mod specific Creative Mode Tab. The tutorial suggests that for adding items to a modded tab, this is best done when creating the DeferredHolder object for the Creative Mode Tab (I assume for less overhead, and Events being essentially required for adding to vanilla tabs that will already existing when the mod startup begins). This I believe is done within the block following the `.displayItems()` call.

Note: For my example mod, I place the code for my own items in a folder in the `main/java/.../canatweaks/items`. This is to split off functionality and purpose. This may become more of a detriment than a benefit depending on how more complex interactions with blocks and items become, but feels prudent for now to avoid a single config enourmous class.

### 6. A Note about ExampleMod and Config.

While this should be fairly intuitive, the Config class needs to be called on in the ExampleMod/CanaTweaks class in order to be operable. I realized this when in CanaTweaks2, there was no reference to Config, but there was in the unmodified version of the tutorial I am following. Unfortunately, this did not automatically allow me to modify anything in the Config menu from the NeoForge Mod menu, so that may require more investigations.

### 7. Events and Listeners in FML

I am aware of the concept of Events and Listeners in general and think it is high time that I understood the implementation for FML. Scanning the start of the IEventBus interface for FML makes one surprising thing clear, registering Classes and Objects to listen for Events is roughly equivalent, and very easy. At some point in the Class definition or creation of the Object respectively, call the `.register()` method. This should scan the static methods of a Class for those with a SubscribeEvent annotation, and the non-static methods of an Object annotated with SubscribeEvent, and create the Listeners Automatically. Note: I would understand that this method is called on a class that implements the IEventBus interface, and the method is supplied with the object or class that the should have Listeners created. It would follow that the specific object the `.register()` method is called on is of the utmost import, but I do not have a sense of how other than the base 

### 8. Java Best Practices and FML Implementations

While setting up a class to manage my first modded block in Minecraft, I realized that creating separate classes for items and blocks 1) separates out what I conceptualized as highly distinct concepts, and 2) creates a requirement that multiple DeferredRegisters for Items must be created, as it only makes sense that any block in the world has an associated Block_Item which can be in the player's inventory. While I see the former as following general practice guidelines for Java, the latter creates logistical issues that I would rather avoid. That being either I have two Deferred registers for Items, or I register Block_Items in the Item class, assuming the DeferredRegister for Blocks is/can be created first. Given this, I will be moving Items and Blocks into a single class, I plan atm to call this something like `ModContent`, which is separate from the mod's primary class. This separation is largely a style choice, as I find the tutorial mod somewhat overwhelming in the amount of information that is stored solely in the primary class. Further, I intend to break future functionality out into specific classes later, as more interactive/functional blocks will require additional data and code. And as such I would like to specify such additional behavior and data in separate classes when appropriate. I should also note, that there probably should still be a central place that Items and Blocks are registered from, and only the functionality that requires outside code (ie, features that vanilla or NF options don't allow) goes into outside classes.

### THE END