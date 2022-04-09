/*
DataLoader.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/

using System;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader {

    private int _nextLineToRead = 1;
    private string[] _data;


    private Dictionary<string, string> _palette = new Dictionary<string, string>() {
        {"0", "FFFFFF"},
        {"1", "FFF8B8"},
        {"2", "FFD635"},
        {"3", "FFB470"},
        {"4", "FFA800"},
        {"5", "FF99AA"},
        {"6", "FF4500"},
        {"7", "FF3881"},
        {"8", "E4ABFF"},
        {"9", "DE107F"},
        {"10", "D4D7D9"},
        {"11", "BE0039"},
        {"12", "B44AC0"},
        {"13", "9C6926"},
        {"14", "94B3FF"},
        {"15", "898D90"},
        {"16", "811E9F"},
        {"17", "7EED56"},
        {"18", "6D482F"},
        {"19", "6D001A"},
        {"20", "6A5CFF"},
        {"21", "51E9F4"},
        {"22", "515252"},
        {"23", "493AC1"},
        {"24", "3690EA"},
        {"25", "2450A4"},
        {"26", "00CCC0"},
        {"27", "00CC78"},
        {"28", "00A368"},
        {"29", "009EAA"},
        {"30", "00756F"},
        {"31", "000000"},
    };
    

    public void LoadFile() {
        _data = System.IO.File.ReadAllLines(Application.persistentDataPath + "\\cleanData.txt");
    }


    public TileData ReadNextTile() {

        string[] splitLine = _data[_nextLineToRead].Split("|");

        string colorID = splitLine[0];
        string hexColor = _palette[colorID];

        Color32 color = ToColor(int.Parse(hexColor, System.Globalization.NumberStyles.HexNumber));
        //Debug.Log(color);

        string[] positionValues = splitLine[1].Split(",");

        Vector2Int location = new Vector2Int(int.Parse(positionValues[0]), int.Parse(positionValues[1]));
        //Debug.Log(location);


        _nextLineToRead++;

        return new TileData(location, color);
        
        
    }

    public Color32 ToColor(int HexVal) {
        byte R = (byte)((HexVal >> 16) & 0xFF);
        byte G = (byte)((HexVal >> 8) & 0xFF);
        byte B = (byte)((HexVal) & 0xFF);
        return new Color32(R, G, B, 255);
    }
}

