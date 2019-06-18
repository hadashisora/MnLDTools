# MnLDTools
A few things I made for my attempts to rip models from Mario & Luigi: Dream Team (Bros.) / Mario & Luigi RPG 4 Dream Adventure
While I never succeded to properly rip those models (curse those UV coordinates), I though I'd put these up in case they needed it, since no tools were posted by anyone working on ripping this game.

#### Credits:
* Teawater - RE and research on basically everything
* TheFearsomeDzeraora - shoddy programming and offsets for EUR/JPN

#### Note:
* This code was written some time ago and has many poor decisions. For this release I just commented most of it and cleaned up some stuff. The SPICA edits I made are awful an are more experiments than anything else, so use this edition at your own risk

#### Included:
* MnL4Extractor - tool for extracting .dat file based on offset tables found in code.bin and .cro's
* FilePtrRef.txt - a table containing table offsets for archives, to be used with MnL4Extractor (Note: this document doesn't accomodate for patched versions!)
* MnL4MapReader - tool for "reading/parsing" map files. In all seriousness, was made by me just to rename over 600 files without having to open them up individually in SPICA every time
* Somewhat butchered SPICA - required for MnL4MapReader to function

#### MnL4Extractor usage:
1. Input code.bin or .cro location
2. Find the file you want to extract
3. Enter the corresponding adress based on the file and region of your game (look it up in FilePtrRef.txt)
4. Drag and drop your file onto the drag-drop area
5. Wait
6. DONE

#### MnL4MapReader usage:
##### Renaming extracted map files:
1. Open the directory containing .mnlmap files you've obtained through using MnL4Extractor
2. Wait for it to load (it may run out of RAM doing that and crash tho)
3. You'll see a text box with a name and a list box with text strings from the cgfx file, aswell as SPICA window will load the current file. Clicking any of the list box items will put the string into the name text box
4. Do this for as many files in the list as you want
5. Click "Save" to apply renaming to actual files. Note: if you get an exception about file with such name already existing, then you have duplicate filnames in you list, just go back and rename them if this happens
6. DONE
##### Extracting CGFX/BCRES from mnlmap:
1. Click on "extract cgfx". You don't need to have a folder normally loaded into the app to do this
2. Select the folder with .mnlmap files
3. Wait
4. DONE
