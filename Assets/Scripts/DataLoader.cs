/*
DataLoader.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/

using System;
using UnityEngine;

public class DataLoader {

    private int _nextLineToRead = 1;
    private string[] _data;


    public void LoadFile() {
        _data = System.IO.File.ReadAllLines(Application.persistentDataPath + "\\2022_place_canvas_history-000000000001.csv");
    }


    public TileData ReadNextTile() {

        string[] splitLine = _data[_nextLineToRead].Split(",");

        Color color = ToColor(int.Parse(splitLine[2].Substring(1), System.Globalization.NumberStyles.HexNumber));
        //Debug.Log(color);

        
        Vector2Int location = new Vector2Int(int.Parse(splitLine[3].Substring(1)), int.Parse(splitLine[4].Substring(0, splitLine[4].Length - 1)));
        //Debug.Log(location);


        _nextLineToRead++;

        if (location.x < 1000 && location.y < 1000) {
            return new TileData(location, color);
        }
        return ReadNextTile();
        
        
    }

    public Color32 ToColor(int HexVal) {
        byte R = (byte)((HexVal >> 16) & 0xFF);
        byte G = (byte)((HexVal >> 8) & 0xFF);
        byte B = (byte)((HexVal) & 0xFF);
        return new Color32(R, G, B, 255);
    }
}

