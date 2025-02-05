# Decompiling and Modding Minecraft

I would like to learn to build Minecraft mods. I have tried this in the past and failed pretty miserably.
The big thing that I remember from my previous attempts is that, in the process of going from someone who owns a Minecraft liscence to someone who can build mods is multi-step. IIRC, the process begins with selecing an MC version, applying one of the available mappings to the obfuscated source code, and selecting a modding framework. While I am sure there are ways to build simple mods without the use of a mod loader, I think it will be far more easier to rely on one.

In the past I have tried to use the Forge loader which I have a connotation of being the old mainstay of the MC modding scene (though may not be the first), but is no longer the dominant mod loader that it used to be. I know of the following other mod loaders: NeoForge(I am unsure if this is an independent fork of Forge, or a new loader that takes structural queues from Forge), Fabric, Quilt (a fork of Fabric apparently). I vaguely remember there being more but cannot remember the names. At this early stage, I am going to look into how the various loaders differ and consider what features might be most important to me. I know that Forge was not super simple to set up, which makes me somewhat want to try a different one this time around.

### Impressions

1. Forge: Seemingly the original mod loader for Minecraft, Forge is robust, allows for mod-management, expansive API, and has an extensive history.

2. Fabric: A recent loader that aims to put access to the newest game features first, updating rapidly after the game does. Fabric does not have as much of a following, history, or as expansive an API. Further, there is/was no built in mod management, making this option less appealing to me.

3. Quilt: Apparently a fork of Fabric, Quilt seems to be an attempt to move Fabric one or a couple of steps closer to Forge. The first article I read is clearly written for those looking for a mod loader to play based on, but I think it pushes me towards Quilt as a first choice.

4. NeoForge: As I suspected, NeoForge does seem to be a fork of Forge, seemingly as a result of poor leadership. Recent changes to the codebase has improved performance over Forge and is seemingly developed by the rest of the team behind Forge. Given what I have now read, I am going to take th next steps with NeoForge, IE, finding and watching 'getting started with NeoForge'.

# Issues

1. The first (because of course it is a system problem that gives me trouble) issue I ran into is my device being unable to find some gradle plug in it needs to progress with the gradle build process (if that is proper parlence). Honestly I am still shaky on what Gradle is exactly, and probably need to spend some time learning that before anything else.