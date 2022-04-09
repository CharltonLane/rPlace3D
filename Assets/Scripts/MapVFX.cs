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
        _dataLoader.LoadFile(0);
        _dataLoader.ReadNextTile();
    }

    void Update() {
        CreateCube(_dataLoader.ReadNextTile());
    }

    private void CreateCube(TileData tileData) {

        _vfx.SetVector3("Position", new Vector3(tileData.Location.x, _towerHeights[tileData.Location.x, tileData.Location.y], -tileData.Location.y) * _mapScale);
        _vfx.SetVector4("Color", RGBToHDR.ToHDR(tileData.Color));

        _towerHeights[tileData.Location.x, tileData.Location.y]++;

        _vfx.SendEvent("SpawnParticle");
    }
}

