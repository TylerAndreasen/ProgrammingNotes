# Sky AI

I have had the idea in my head that I should one day create a learning agent that I teach to play Skyrim. In truth, the biggest thing I have going for me is that I have experience programming. What I don't really have is experience with proper learning algorithms, or meaningful experience with Papyrus (the scripting language that Skyrim uses).

If I intend to really tackle this challenge, I will need to spend time with both of these things, and really take time to consider how best to think about teaching and training the agent before implementing anything.
And there are a number of important questions I need to answer about what I am going to ask the AI to do:
- What meta techniques do I employ to simplify training? (disabling enemy ai, navigating areas I make/debug cells)
- Navigation
- Combat
- Fast Travel Usage (Allow, Reward, possible given technical restraints?)
- Making conversation choices with NPCs
- Deciding on what weapon/spell/shout to equip
    - The AI will have to decide when to use the equiped tools, but how I teach them to select such is also important.
- Health Management (Do I push the agent to learn stealth archerism, or take measures not to? Or do I simply make the player immortal and ignore the health system)