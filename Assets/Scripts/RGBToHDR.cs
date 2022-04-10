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

    // This is a mapping of the r/Place palette from standard RGB to another RGB value that looks identical when rendered using HDR.
    private static Dictionary<Color32, Color32> mapping = new Dictionary<Color32, Color32> {

        { new Color32(255, 248, 184, 255), new Color32(255, 239, 122, 255) }, // Light Yellow.
        { new Color32(255, 214, 53, 255), new Color32(255, 171, 9, 255) }, // Yellow.
        { new Color32(255, 168, 0, 255), new Color32(255, 100, 0, 255) }, // Yellow/Orange.
        { new Color32(255, 69, 0, 255), new Color32(253, 16, 0, 255) }, // Orange/Red.
        { new Color32(190, 0, 57, 255), new Color32(131, 0, 10, 255) }, // Ruby Red.
        { new Color32(109, 0, 26, 255), new Color32(39, 0, 3, 255) }, // Dark maroon.
        { new Color32(129, 30, 159, 255), new Color32(56, 3, 88, 255) }, // Dark Purple.
        { new Color32(126, 237, 86, 255), new Color32(39, 144, 19, 255) }, // Lime.
        { new Color32(0, 204, 120, 255), new Color32(0, 154, 48, 255) }, // Emerald Green.
        { new Color32(0, 163, 104, 255), new Color32(0, 93, 35, 255) }, // Dark Green.
        { new Color32(0, 117, 111, 255), new Color32(0, 45, 41, 255) }, // Dark Blue/Green.
        { new Color32(0, 204, 192, 255), new Color32(0, 154, 134, 255) }, // Turquoise.
        { new Color32(0, 158, 170, 255), new Color32(0, 87, 103, 255) }, // Blue/Green.
        { new Color32(255, 153, 170, 255), new Color32(255, 81, 103, 255) }, // Osu Pink.
        { new Color32(255, 56, 129, 255), new Color32(255, 10, 56, 255) }, // Dark Osu Pink.
        { new Color32(222, 16, 127, 255), new Color32(186, 1, 54, 255) }, // Pink/Purple.
        { new Color32(73, 58, 193, 255), new Color32(17, 11, 136, 255) }, // Dark Blue/Purple.
        { new Color32(106, 92, 255, 255), new Color32(37, 27, 255, 255) }, // Light Blue/Purple.
        { new Color32(180, 74, 192, 255), new Color32(116, 17, 134, 255) }, // Purple.
        { new Color32(228, 171, 255, 255), new Color32(198, 104, 255, 255) }, // Light Purple.
        { new Color32(255, 180, 112, 255), new Color32(255, 116, 41, 255) }, // Beige.
        { new Color32(156, 105, 38, 255), new Color32(85, 36, 5, 255) }, // Brown.
        { new Color32(109, 72, 47, 255), new Color32(39, 17, 7, 255) }, // Dark Brown.
        { new Color32(81, 82, 82, 255), new Color32(21, 22, 22, 255) }, // Dark Grey.
        { new Color32(137, 141, 144, 255), new Color32(64, 68, 71, 255) }, // Grey.
        { new Color32(212, 215, 217, 255), new Color32(168, 173, 177, 255) }, // Light Grey.
        { new Color32(54, 144, 234, 255), new Color32(9, 71, 210, 255) }, // Blue.
        { new Color32(36, 80, 164, 255), new Color32(4, 20, 95, 255) }, // Dark Blue.
        { new Color32(81, 233, 244, 255), new Color32(21, 208, 231, 255) }, // Light Blue.
        { new Color32(148, 179, 255, 255), new Color32(76, 115, 255, 255) }, // Sky Blue.
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

