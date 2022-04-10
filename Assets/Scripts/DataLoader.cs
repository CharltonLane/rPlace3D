/*
DataLoader.cs 

Original Author: Charlton Lane
Created: 07/04/2022
Unity Version: 2021.2.18f1
Contributors: 
 - Compact version of the dataset from user 'golslyr'
    https://www.reddit.com/r/place/comments/txvk2d/comment/i3utewb/?utm_source=share&utm_medium=web2x&context=3
 - Hex to RGB method
    https://answers.unity.com/questions/812240/convert-hex-int-to-colorcolor32.html

Description: Load the tile placement data from the various files.
*/


using System.Collections.Generic;
using UnityEngine;

public class DataLoader {

    private int _currentFileIndex = 0;
    private int _nextLineToRead = 0;
    private string[] _data;
    private bool _isMoreData = true;

    // Mapping of colour IDs to their HEX value.
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


    public void LoadFile(int fileIndex) {
        _data = System.IO.File.ReadAllLines(Application.persistentDataPath + "\\placeData" + fileIndex.ToString() + ".txt");
    }


    public bool IsMoreData() {
        // Used to see if we should stop asking for new tile placement data.
        return _isMoreData;
    }


    public TileData ReadNextTile() {
        // Read the data for the next tile to be placed from file and return a TileData.

        // Debug info.
        if (_nextLineToRead % 100000 == 0) {
            Debug.Log("Placed " + (_nextLineToRead + (_currentFileIndex * 10000000)) + " tiles.");
        }


        // Reached the end of the file, need to load the next file and get data from there.
        if (_nextLineToRead >= _data.Length) {
            _nextLineToRead = 0;
            _currentFileIndex++;

            LoadFile(_currentFileIndex);
        }


        // Get the color and position from the read line.
        string[] splitLine = _data[_nextLineToRead].Split("|");

        string colorID = splitLine[0];
        string hexColor = _palette[colorID];

        Color32 color = ToColor(int.Parse(hexColor, System.Globalization.NumberStyles.HexNumber));

        string[] positionValues = splitLine[1].Split(",");

        Vector2Int location = new Vector2Int(int.Parse(positionValues[0]), int.Parse(positionValues[1]));


        // Increment this ready for next time.
        _nextLineToRead++;


        // If the next call will be the end of the file, and need data from the next file.
        if (_nextLineToRead >= _data.Length) {
            // If we're on the last file (There are only 16 files).
            if (_currentFileIndex >= 16) {
                // This flag makes it so this will not be called again.
                _isMoreData = false;
            }
        }

        return new TileData(location, color);
    }


    public Color32 ToColor(int HexVal) {
        // Convert Hex to RBG and return a Color32.
        // https://answers.unity.com/questions/812240/convert-hex-int-to-colorcolor32.html
        byte R = (byte)((HexVal >> 16) & 0xFF);
        byte G = (byte)((HexVal >> 8) & 0xFF);
        byte B = (byte)((HexVal) & 0xFF);
        return new Color32(R, G, B, 255);
    }
}

