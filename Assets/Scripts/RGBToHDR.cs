/*
RGBToHDRMapping.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBToHDR {


    private static Dictionary<Color32, Color32> mapping = new Dictionary<Color32, Color32> {
        { new Color32(109, 0, 26, 255), new Color32(39, 0, 3, 255) }, // Dark maroon.
        { new Color32(255, 248, 184, 255), new Color32(255, 239, 122, 255) }, // Light Yellow.
        { new Color32(255, 214, 53, 255), new Color32(255, 171, 9, 255) }, // Yellow.
        { new Color32(255, 168, 0, 255), new Color32(255, 100, 0, 255) }, // Yellow/Orange.
        { new Color32(255, 69, 0, 255), new Color32(253, 16, 0, 255) }, // Orange/Red.
        { new Color32(129, 30, 159, 255), new Color32(56, 3, 88, 255) }, // Dark Purple.
        { new Color32(126, 237, 86, 255), new Color32(39, 144, 19, 255) }, // Lime.
        { new Color32(0, 163, 104, 255), new Color32(0, 93, 35, 255) }, // Dark Green.
        { new Color32(255, 153, 170, 255), new Color32(255, 81, 103, 255) }, // Osu Pink.
        { new Color32(180, 74, 192, 255), new Color32(116, 17, 134, 255) }, // Purple.
        { new Color32(156, 105, 38, 255), new Color32(85, 36, 5, 255) }, // Brown.
        { new Color32(137, 141, 144, 255), new Color32(64, 68, 71, 255) }, // Grey.
        { new Color32(212, 215, 217, 255), new Color32(168, 173, 177, 255) }, // Light Grey.
        { new Color32(54, 144, 234, 255), new Color32(9, 71, 210, 255) }, // Blue.
        { new Color32(36, 80, 164, 255), new Color32(4, 20, 95, 255) }, // Dark Blue.
        { new Color32(81, 233, 244, 255), new Color32(21, 208, 231, 255) }, // Light Blue.
        { new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 255) }, // White.
        { new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255) }, // Black.
    };

    public static Color ToHDR(Color32 col) {

        if (mapping.ContainsKey(col)) {
            return mapping[col];
        }
        Debug.Log("Couldn't find color: " + col + " in mapping.");
        return col;
    }

}

