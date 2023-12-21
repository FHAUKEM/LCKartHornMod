Describes planned functionality and goals, sometimes for specific versions.

## Future versions

- [ ] Implement Hell horns system.
    - Current idea: a round has a small chance to be a hell round.
    - During a hell round, all players are assigned a horn they can play by pressing the horn button.
    - This horn is selected from a separate list of hell horns, if available.
    - Might require use of LCSoundSystem or custom networking.
- [ ] Implement alternative system:
    - Instead of replacing the clown horn, everyone will have a horn button.
    - This button will play a random horn sound effect.
    - During hell rounds, these will be selected from the hell horns instead.
- [ ] Add config file for Hell horns system.
- [ ] Allow rebinding of Horn key in-game.

## Maybe future versions

- [ ] Add custom networking to _check_ for synchronization of horn sound effects.
- [ ] Add config file for custom networking.
- [ ] Loading optimization.
    - First, only gather SFX filenames and count.
    - Fully load audio files only when selected instead of all of them.

## Very maybe future versions

- [ ] Expand custom networking to download missing horn sound effects on server join.
- [ ] Add config file for downloading missing horn sound effects.
- [ ] Add menu option to ask player if they want to download missing horn sound effects.
- [ ] DSP convolution reverb to create proper "far horn" effects automagically

## Completed versions

### 1.0.0

- [x] Add config file for volume of far horns, with option to disable.
- [x] Add config file explanation to README.
- [x] Create icon.
- [x] Create Manifest.json for Thunderstore.
- [x] Allow creation of sound effect packs using modding store (e.g. Thunderstore).
- [x] Finalise README, CHANGELOG and ROADMAP.
- [x] Prepare Git repository for public release.

## Scrapped plans

- [ ] Add config file for overall horn volume.

# Have any suggestions?

Drop them in this mod's thread in the Unofficial Lethal Company Modding Discord server.