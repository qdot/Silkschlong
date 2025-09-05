# Silkschlong - Buttplug.io mod for SilkSong

Day 1 Silksong Buttplug Mod!

... That does about as much as you'd expect of a Day 1 mod that I've had an hour to work on.

## Features

- Vibrate on successful heal
- Vibrate on adding silk (i.e. damaging enemies)

Want more features? File issues! Add more should be pretty easy, as well as support for other toys like strokers.

Should work on Windows x64 or Linux/Steam Deck if you know how to load BepInEx mods on Steam Deck.

## How to use

1. Install BepInEx 5, either from [Github](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.23.3) (download version for your OS, most likely win_x64, then put it in your Silksong game dir, most likely `C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight Silksong`) or [Thunderstore](https://thunderstore.io/c/hollow-knight-silksong/p/BepInEx/BepInExPack_Silksong/)
2. Start game
3. Exit game
4. Download the latest zip from our releases
5. Unpack into `C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight Silksong\BepInEx\plugins\`
6. Install [Intiface Central](https://intiface.com/central)
7. Start Silksong, make sure Intiface Central shows "Silkschlong Connected" message
8. Play!

## How to compile

This should "just work" as long as you have Silksong installed at the default location (`C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight Silksong`) with BepInEx already installed. Note that `Buttplug.dll` dependency may need to be hand copied because I'm still figuring out how Rider works with dependencies and mods.