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



    private int _positionAttrID;
    private int _colorAttrID;
    private int _tilePerFrameAttrID;

    private Texture2D _SpawnPositionTex;
    private Texture2D _ColorTex;

    private int _tilesPerFrame = 1000;

    private bool _isPlaying = true;


    void Start() {
        _dataLoader.LoadFile(0);
        //_dataLoader.ReadNextTile();

    
        //Get property nameID
        _positionAttrID = Shader.PropertyToID("PositionTex"); // Texture2D field
        _colorAttrID = Shader.PropertyToID("ColorTex");
        _tilePerFrameAttrID = Shader.PropertyToID("TilesPerFrame"); // int field

        _SpawnPositionTex = new Texture2D(_tilesPerFrame, 1, TextureFormat.RGBAFloat, false);
        _ColorTex = new Texture2D(_tilesPerFrame, 1, TextureFormat.RGBAFloat, false);

        _vfx.SetInt(_tilePerFrameAttrID, _tilesPerFrame);
    }

    void Update() {
        //CreateCube(_dataLoader.ReadNextTile());

        if (Input.GetKeyDown(KeyCode.Space)) {
            _isPlaying = !_isPlaying;
        }

        if (_isPlaying) {
            CreateCubes();
            _vfx.Play();
        }
    }

    private void CreateCubes() {

        for (int i=0; i < _tilesPerFrame; i++) {
            TileData tileData = _dataLoader.ReadNextTile();
            Vector3 pos = new Vector3(tileData.Location.x, _towerHeights[tileData.Location.x, tileData.Location.y], -tileData.Location.y) * _mapScale;
            _SpawnPositionTex.SetPixel(i, 0, new Color(pos.x, pos.y, pos.z));
            _ColorTex.SetPixel(i, 0, RGBToHDR.ToHDR(tileData.Color));
            _towerHeights[tileData.Location.x, tileData.Location.y]++;
        }

        _SpawnPositionTex.Apply();
        _ColorTex.Apply();

        _vfx.SetTexture(_positionAttrID, _SpawnPositionTex);
        _vfx.SetTexture(_colorAttrID, _ColorTex);
    }

    private void CreateCube(TileData tileData) {

        /*
        // bake positions and lifetime to texture
        var positionsLifetimes = _SpawnPositionTex.GetRawTextureData<Vector4>();
        Vector4 tmp = new Vector4();
        for (var i = 0; i < count; i++) {
            var e = VFXEventEmitter.emitters[groupID][i];
            tmp.Set(e.transform.position.x, e.transform.position.y, e.transform.position.z, e.lifetime);
            positionsLifetimes[i] = tmp;
        }
        _SpawnPositionTex.Apply(false);
        _vfx.SetTexture(positions, _SpawnPositionTex);

        _vfx.SetVector3("Position", new Vector3(tileData.Location.x, _towerHeights[tileData.Location.x, tileData.Location.y], -tileData.Location.y) * _mapScale);
        _vfx.SetVector4("Color", RGBToHDR.ToHDR(tileData.Color));

        _towerHeights[tileData.Location.x, tileData.Location.y]++;

        _vfx.SendEvent("SpawnParticle");
        */
    }
}

