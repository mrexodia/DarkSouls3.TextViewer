# How to extract the required files from the game?

1. Get [BinderTool](https://github.com/Atvaark/BinderTool) and put it in your `PATH` environment variable.
2. `BinderTool.exe Data1.bdt data`.
3. Copy the folders from `data\msg` in a separate folder.
4. Run `extractbnd.bat` from that folder.
5. Run `extractfmg.bat` from that folder.
6. Run `deletefmg.bat` from that folder.
7. Run `DarkSouls3.Preprocessor` to properly extract the textual data to JSON.