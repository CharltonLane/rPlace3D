/*
TileData.cs 

Original Author: Charlton Lane
Created: 07/04/2022
Unity Version: 2021.2.18f1
Contributors: 

Description: Struct to store data bout a single tile placement.
*/


using UnityEngine;

public struct TileData {

    public Vector2Int Location { get; set; }
    public Color32 Color { get; set; }


    public TileData(Vector2Int loc, Color32 col) {
        Location = loc;
        Color = col;
    }

}

