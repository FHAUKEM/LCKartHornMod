# LCKartHornMod

This mod replaces all clown horn noises with pseudo-randomly selected sound effects. Horn sound effects are loaded
automatically.

Inspired by the brainrot that is SRB2K's HornMod, I've tried to recreate this in Lethal Company.

Only players that want this functionality, need to install this mod. All other players will hear the default clown horn
sound effect. There is no requirement for the host to have this mod installed.
___

## Installation

1. Install BepInEx for Lethal Company. Create a `BepInEx/plugins` folder, or run the game once and it will create it
   automatically.
1. Place the `LCKartHornMod.dll` file into the `BepInEx/plugins` folder.
1. Run the game once. This should create an empty `Horns` folder in `BepInEx/plugins`.
1. Place all desired horn sound effects in `BepInEx/plugins/Horns`, as `.ogg` files.

If you received a Horns folder with this mod, you can install that by placing it in `BepInEx/plugins` folder.

### Sound effect synchronization

If all connected players have the exact same files in the Horns folder, the sound effects that all players hear is the
same.
In the case that not all players hear the same sound effect from the horn, check this first:

- `Horns` folder contains the exact same number of files.
- All players have the same file names for the horns.

___

## Compatibility

This mod should be compatible with all other mods, except those that change the clown horn sound effect.

### Known issues and limitations

If you find any issue(s) not listed here, please contact me.

- This mod requires all players to have the same horn sound effects installed. If not, the horn sound effects will not
  be synchronized between players.
- The sound effects are loaded in a single thread, which may cause an increase in startup time if you have a lot of
  sound effects installed.

Also, this is my first mod, first time using C# and first time working with Unity. So, if you read this code and think "
what the heck is this", feel free to contact me, make improvement PRs on the GitHub, etc.