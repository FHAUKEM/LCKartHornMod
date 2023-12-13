# LCKartHornMod
This mod replaces all clown horn noises with pseudo-randomly selected sound effects. Horn sound effects are loaded automatically.

Inspired by the brainrot that is SRB2K's HornMod, I've tried to recreate this in Lethal Company. 

## Installation
1. Install BepInEx for Lethal Company. Create a `BepInEx/plugins` folder, or run the game once and it will create it automatically.
1. Place the `LCKartHornMod.dll` file into the `BepInEx/plugins` folder.
1. Run the game once. This should create an empty `Horns` folder in `BepInEx/plugins`.
1. Place all desired horn sound effects in `BepInEx/plugins/Horns`, as `.ogg` files.

If you received a Horns folder with this mod, you can install that by placing it in `BepInEx/plugins` folder.

## Sound effect synchronization
If all connected players have the exact same files in the Horns folder, the sound effects that all players hear is the same. 
In the case that not all players hear the same sound effect from the horn, check this first:
- `Horns` folder contains the exact same number of files.
- All players have the same file names for the horns.

## Compatibility and issues
This mod should be compatible with all other mods, except those that change the clown horns' sound effect. 

If you find any issues or incompatibilities, please send it to the me.

# Design considerations

If you know better than me, please send me a message. This is my first time modding a game. And although I have a theoretical computing science background, I quickly found out that game programming and modding is not at all comparable to my theory :').

- This mod uses scrap value as a base seed for horns.
  - This means no extra netcode is necessary, as the game already synchronizes scrap value. It also means horn sounds are consistent across sessions, since scrap values should be consistent.
  - If you ever are in the situation that numerous horns have the same scrap value, please tell me if everything still works as expected. 
- Only *.ogg files are accepted.
  - This choice was made since Kart horns are always in Ogg Vorbis format. Adding other file formats is trivial. Contact me if you feel this is a good addition; I didn't personally see the need.
- Horns are softly audible for a long distance.
  - Lethal Company has two sound effects for horns: regular and "distant". Instead of requiring the users of this mod to manually create distant versions of horns, I've just used the Unity to lower the volume and use this as the distant horn. It still works weirdly, if you prefer to only hear horns from close by, tell me. I'll add a config option for this.
- Optimization is lacking by design.
  - I did not care about optimization. Everything my mod does runs only once, on relatively rare items, and I haven't ran into any issues with 200+ (small) sound effects. If you experience issues, contact me.
