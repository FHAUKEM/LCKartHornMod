# LCKartHornMod

This mod replaces all clown horn noises with pseudo-randomly selected sound effects. Sound effect files are loaded
automatically, so this mod can also be used for custom sound effect packs.

This mod was inspired by the brainrot that is SRB2K's HornMod, I've tried to bring this to Lethal Company.

Only players that want this functionality, need to install this mod. Players without the mod will hear the default clown
horn
sound effect. There is no requirement for the host to have this mod installed.
___

## Manual installation

1. Install BepInEx for Lethal Company. Create a `BepInEx/plugins` folder, or run the game once and it will create it
   automatically.
1. Place the `LCKartHornMod.dll` file into the `BepInEx/plugins` folder.
1. Run the game once. This should create an empty `Horns` folder in `BepInEx/plugins`.
1. Place all desired horn sound effects in `BepInEx/plugins/Horns`, as `.ogg` files.

**No horns are included in this mod by default!**

If you received a manual Horns folder for this mod, you can install that by placing it in `BepInEx/plugins` folder.
Separate sound effects can be installed by placing them in `BepInEx/plugins/Horns`.

Make sure to read the note about sound effect synchronization below.

### Sound effect synchronization

Only if all connected players have the exact same files in the Horns folder, will the sound effects that all players
hear be the
same.
In the case that not all players hear the same sound effect from the horns, check this first:

- `Horns` folder contains the exact same number of files.
- All players have the same file names for the horns.

If the problems persists, please create an issue on GitHub or post in the thread on the unofficial Lethal Company
Modding discord.

### Config file

After launching the game with the mod installed, a config file will be created in `BepInEx/config`. This file currently
contains only a single option: the `FarVolumeReductionFactor`. Currently, the SFXfar is just a lowered volume version of
the original (no reverb or anything). This option allows you to set the volume of the far horns. The default value
is `0.05`, which means the far horns are 5% as loud as the normal horns. Setting this to `0` will disable the far horns
entirely.
___

# Creating sound effect packs

To create sound packs, all your mod needs is a `BepInEx/plugins/Horns` folder with `.ogg` files in it. The mod will
automatically load all `.ogg` files in this folder. Only `.ogg` files are supported at the moment, since these are the
file format used in the SRB2K HornMod.

Make sure to have this mod as a dependency.

___

# Compatibility

This mod should be compatible with all other mods, except those that change the clown horn sound effect. There may also
be issues with mods that change how sounds are played, but I have not tested this.

## Known issues and limitations

If you find any issue(s) not listed here, please contact me.

- This mod requires all players to have the same horn sound effects installed. If not, the horn sound effects will not
  be synchronized between players.
- The sound effects are loaded in a single thread, which may cause an increase in startup time if you have a lot of
  sound effects installed.

Also, this is my first mod, first time using C# and first time working with Unity. So, if you read this code and think "
what the heck is this", "just do this you idiot", "please delete this from my life", or anything similar, feel free to
post in the thread on the unofficial Lethal Company Modding discord, make PRs on the GitHub, etc.