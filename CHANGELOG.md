_Dates are in 'DD-MM-YYYY' format._
___

## v1.1.0

Released: 22-12-2023
### Changes
- Plugin doesn't create a `Horns` folder anymore.
- Load all sound effects in all LCKartHorns folders under `BepInEx/plugins`, instead of  specifically`plugins/Horns`.
  This allows for multiple sound effect packs to be installed at the same time.
- Ensure all filenames have unique names, to prevent conflicts between sound effect packs.
- Updated README to more clearly reflect its purpose as a SFX loader.

## v1.0.0

Released: 22-12-2023
Release on modding stores.

### Added

- Added icon
- Finalised README, CHANGELOG and ROADMAP
- Create Manifest.json for Thunderstore
- Expanded README with more information on how to use plugin to create and load custom sound effect packs.
- Added config option for far horn volume and disabling far horns.

___

## v0.6.1

Released privately: 20-12-2023

### Bug fixes

- Fixed a problem that occurred when no sound effects were installed. The plugin now disables itself when no sound
  effects
  could be loaded.

___

## v0.6.0

Released privately: 20-12-2023

### Bug fixes:

- Fixed a bug where horns would not always be synchronized between players (hopefully).

___

## v0.5.0

Released privately: 13-12-2023

- Initial beta release.