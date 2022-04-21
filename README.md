# rPlace3D
3D Visualisaion of r/place 2022 

This project was an exploration of handling large data for display in a 3D environment. The program will place the tiles from r/place as cubes on a plane, building towers of cubes whenever a tile changes colour.This allows you to visualise high-activity areas of the board, and to see which colours those areas are frequently changing between.

The r/place data has been processed to remove the timestamp and hashed user ID, leaving only a position and tile colour ID. Tiles were sorted before removing the timestamp however, so they are in chronological order.

## Installation
You can download the built program from the releases section. You should download both the rPlace3D.zip and the rPlaceData.zip.

The rPlace3D.zip can be extracted anywhere and contains the program's executable. You should run this once to create the folder to extract the data into.

The rPlaceData.zip should be extracted into `C:/Users/<user>/AppData/LocalLow/Charlton Lane/rPlace3D` This should leave the files under, e.g. `.../rPlace3D/rPlaceData/placeData0.txt`

From here, running the program will begin the replay of r/place within the tool.

## Controls
The controls are listed in the program; hit ESC to see them.
- The main way to use the program is to fly around using WASD and the mouse with right click held down.
- Once the program begins to lag, you can press F to flatten the tiles down.
- At any time if you notice something interesting, you can pause the playback using SPACE, and fly around to inspect.
- There is also a minimap that can be toggled using M. Do note though, having this enableed will drop your framerate noticebly as it is implemented using a second camera, which requires the scene to be rendered twice!

## Known Issues
- I haven't implemented the bulk placement of blocks that occured whenever reddit moderators placed large rectangles of a single colour to cover an area.
- There is a noticeable (but brief) freeze/lag whenever a new file worth of data is being loaded.
