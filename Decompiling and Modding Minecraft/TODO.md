# TODO

1. Make the Free Sample eddible. What does it return in game?
    Lets suppose the Free Sample is a cup of coffee. It makes the most sense to craft the Free Sample in the brewing stand (unless I make a coffee pot).
    In that case, what do I use for brewing. My thought is to make a new item crafted potentially with cocoa beans, sugar, and wheat, called Instant Coffee, and use that in the ending recipie.
2. Reimplement the block from the tutorial, what does breaking the block drop (with and without the Silk Touch enchant)?
3. What simple feature from the idea board could I implement?
4. Does changing resource files (other than textures) get applied when only running `gradlew runClient`?
5. How to add custom recipies with vanilla and or modded items?
6. Emoticon Masks: This could be adorable


Advanced:
1. Diable Glowsquid spawning?
2. Spawn a few wither skeletons on Wither Boss spawn?
3. Without distributing modified textures, invert stone brick variant textures?
4. Apply tag to Moss blocks that require a hoe for fast mining?
5. Tilling grass/dirt in range of water immediately creates hydrated farmland?
6. Change default drop item keybind to something that isn't `q`?
7. Toggle for item entities having non-random spawning velocities?



Expert
1. Create Phantom Boss that doesn't spawn for *many* days of insomnia?
    This will almost certainly require something like blockbench and a huge amount of work learning animation, tells/queues for attacks, important engine hooks, and much more.
2. Uncomfy Mode: All square block textures are rotated 90 deg, crafting recipies are changed and or rotated?
    This may be best achieved in the form of a texture pack, possibly by dynamically creating and applying such at runtime if possible. Also, check MC EULA to see if distributing ripped or modified textures is chill.
3. ?? Revert Copper bulbs to original Tick implementation?
    It will be important to note in the description for this toggle that other copper bulb builds will likely not work or break themselves if moved from one version to another.