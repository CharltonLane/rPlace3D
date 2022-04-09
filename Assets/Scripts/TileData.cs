/*
TileData.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/


using UnityEngine;

public struct TileData {

    public Vector2Int Location { get; set; }
    public Color Color { get; set; }

    public TileData(Vector2Int loc, Color col) {
        Location = loc;
        Color = col;
    }

}

