# Order of Operations

I realized while reading the `Config.java` and `ExampleMod.java` files that to successfully add 1) an unnamed item, 2) an unnamed block, and 3) a Creative Mode Inventory Tab containing one or both of the previous, a huge number of things must occur in the Constructor of the `ExampleMod.java`. While this is not a comprehensive list of all things that exist in the two files, this is a key section of information. The other primary thing I need to wrap my head around at this time is the `ModConfigSpec`, which I would understand to be a mod-wise register of everything that exists in the mod for organization and configuration purposes.

1. Add the method `commonSetup()` to the NeoForge `modEventBus`. I would understand this to be an example of the Event/EventListener pattern that I learned in relation to other gamedev engines.
2. Register the previously created Blocks, Items, and Creative Mode Inventotry Tab to the `modEventBus`.
3. In the case that the implemented class has functions annotated with `@SubscriberEvent` (ie, is listening for events), register the instance of the mod class with the NeoForge Event Bus.
4. Register Items and Blocks to the mod's Creative Mode Tab (note: the example Mod does not do this, likely to show an interested developer the difference.)
5. Register the Mod with NeoForge so that the mod and it's config file can be loaded by NeoForge.