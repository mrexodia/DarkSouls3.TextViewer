# How to extract the required files from the game?

1. Get [BinderTool](https://github.com/Atvaark/BinderTool) and put it in your path.
2. `BinderTool.exe Data1.bdt data`.
3. Copy the files from `bndfiles.txt` in a separate folder.
4. Run `extractbnd.bat` from that folder.
5. Run `extractfmg.bat` from that folder.
6. Run `deletefmg.bat` from that folder.
7. Modify the source code of the preprocessor to properly extract the textual data to JSON.