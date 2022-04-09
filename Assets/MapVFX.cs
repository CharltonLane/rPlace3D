/*
MapVFX.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MapVFX : MonoBehaviour {


    private int[,] _towerHeights = new int[2000, 2000];

    private DataLoader _dataLoader = new DataLoader();

    [SerializeField] private float _mapScale = 1;

    [SerializeField] private VisualEffect _vfx;

    void Start() {
        _dataLoader.LoadFile();
        _dataLoader.ReadNextTile();
    }

    void Update() {
        TileData tile = _dataLoader.ReadNextTile();
        CreateCube(tile);
    }

    private void CreateCube(TileData tileData) {

        Vector3 position = new Vector3Int(tileData.Location.x, _towerHeights[tileData.Location.x, tileData.Location.y], -tileData.Location.y);

        position *= _mapScale;

        _vfx.SetVector3("Position", position);



        Vector4 colorVec = new Color(tileData.Color.r, tileData.Color.g, tileData.Color.b, 1);
        //print(colorVec);
        _vfx.SetVector4("Color", tileData.Color);

        _towerHeights[tileData.Location.x, tileData.Location.y]++;

        _vfx.SendEvent("SpawnParticle");
    }
}

