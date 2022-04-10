/*
TileSimulation.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: The main script that passes the read tile placement data to the VFX Graph to create the particles.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TileSimulation : MonoBehaviour {


    private readonly DataLoader _dataLoader = new DataLoader();
    [SerializeField] private VisualEffect _vfx;

    // A 2D array holding information about how many tiles are stacked at each point in the board.
    private int[,] _towerHeights = new int[2000, 2000];
    
    // How large in Unity units each tile is. The walls and floor plane expect this to be 0.1f. 
    private readonly float _mapScale = 0.1f;

    // IDs of properties in the VFX Graph.
    private int _positionAttrID;
    private int _colorAttrID;
    private int _tilePerFrameAttrID;

    // Textures used to store position and colour data of tiles.
    private Texture2D _spawnPositionTex;
    private Texture2D _colorTex;

    // How many tile particles are created each frame. Essentially sets the simulation playback speed.
    private readonly int _tilesPerFrame = 5000;

    // If the simulation is playing (placing tiles).
    private bool _isPlaying = true;

    // Material of the floor. This will have the _currentMapState texture written to it whenever the board is "Flattened".
    [SerializeField] private Material _placeMat;
    private Texture2D _currentMapState;

    void Start() {

        //Get property name ID
        _positionAttrID = Shader.PropertyToID("PositionTex"); // Texture2D field
        _colorAttrID = Shader.PropertyToID("ColorTex");
        _tilePerFrameAttrID = Shader.PropertyToID("TilesPerFrame"); // int field

        _currentMapState = new Texture2D(2000, 2000, TextureFormat.RGBAFloat, false);
        _currentMapState.filterMode = FilterMode.Point;

        // Fill it with white.
        Color32[] fillColorArray = new Color32[2000*2000];
        Color32 white = new Color32(255,255,255, 1);
        for (var i = 0; i < fillColorArray.Length; ++i) {
            fillColorArray[i] = white;
        }
        _currentMapState.SetPixels32(fillColorArray);
        _currentMapState.Apply();


        _dataLoader.LoadFile(15);

    
        // Create our textures to store position and colour data.
        _spawnPositionTex = new Texture2D(_tilesPerFrame, 1, TextureFormat.RGBAFloat, false);
        _colorTex = new Texture2D(_tilesPerFrame, 1, TextureFormat.RGBAFloat, false);

        // Tell the VFX Graph how many tiles (particles) to create each frame.
        _vfx.SetInt(_tilePerFrameAttrID, _tilesPerFrame);
    }

    void Update() {
        //CreateCube(_dataLoader.ReadNextTile());

        // Flatten the board.
        if (Input.GetKeyDown(KeyCode.F)) {
            _placeMat.mainTexture = _currentMapState;
            _vfx.Reinit();
            _towerHeights = new int[2000, 2000];
            _currentMapState.Apply();
        }

        // Play/Pause the simulation.
        if (Input.GetKeyDown(KeyCode.Space)) {
            _isPlaying = !_isPlaying;
        }

        // Create tiles.
        if (_isPlaying) {
            CreateTiles();
            _vfx.Play();
        }
    }


    private void CreateTiles() {
        // Read a new set of tile data and place this data into the textures to be passed to the VFX Graph.
        for (int i=0; i < _tilesPerFrame; i++) {

            TileData tileData = _dataLoader.ReadNextTile();

            Vector3 pos = new Vector3(tileData.Location.x, _towerHeights[tileData.Location.x, tileData.Location.y], -tileData.Location.y) * _mapScale;
            Color color = RGBToHDR.ToHDR(tileData.Color);

            // Encode the position data into a colour.
            _spawnPositionTex.SetPixel(i, 0, new Color(pos.x, pos.y, pos.z));
            // Set the colour ready for use.
            _colorTex.SetPixel(i, 0, color);
            // Increment the height of the tower at this position, so the next tile will be placed above the last.
            _towerHeights[tileData.Location.x, tileData.Location.y]++;

            // Also add data to the currentMapState texture in preparation for flatenning the board.
            _currentMapState.SetPixel(tileData.Location.x, tileData.Location.y, color);
        }

        _spawnPositionTex.Apply();
        _colorTex.Apply();

        // Pass data to the VFX Graph.
        _vfx.SetTexture(_positionAttrID, _spawnPositionTex);
        _vfx.SetTexture(_colorAttrID, _colorTex);
    }

}

