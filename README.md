# LCKartHornMod

Assigns every clown horn spawned a random consistent sound effect. Loads sound effects from `LCKartHorns` folders.

This mod was inspired by the brainrot that is SRB2K's HornMod, I've tried to bring this to Lethal Company.

This is a tool that loads and assigns the sound effects. It does not include any sound effects by default.

While client side, I've made the loading order deterministic, so that all players will hear the same sound effects.

Please see sound effect pack creation below for more information on how to create sound effect packs.
___

## Manual installation

1. Install BepInEx for Lethal Company. Create a `BepInEx/plugins` folder, or run the game once and it will create it
   automatically.
1. Place the `LCKartHornMod.dll` file into the `BepInEx/plugins` folder.
1. Install sound effects
   2.  Either install a sound effect pack (e.g. from the Thunderstore)
   2.  Or manually (place *.ogg files in `BepInEx/plugins/LCKartHorns` folder)
   **No horns are included in this mod by default!**


### Sound effect synchronization

Synchronization of this mod requires players to have **the exact same** sound effects installed.
The mod will still work exactly the same otherwise, but the sound effects will not be synchronized between players.

### Config file

After launching the game with the mod installed, a config file will be created in `BepInEx/config`. This file currently
contains only a single option: the `FarVolumeReductionFactor`. Currently, the SFXfar is just a lowered volume version of
the original (no reverb or anything). This option allows you to set the volume of the far horns. The default value
is `0.05`, which means the far horns are 5% as loud as the normal horns. Setting this to `0` will disable the far horns
entirely.
___

# Creating sound effect packs

To create sound packs, all your mod needs is a `LCKartHorns` folder with `.ogg` files in it. The mod will
automatically load all `.ogg` files in folders with this name. Only `.ogg` files are supported at the moment, since these are the
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