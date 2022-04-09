using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    [SerializeField] private GameObject _cubePrefab;

    private int[,] _towerHeights = new int[2000,2000];

    private DataLoader _dataLoader = new DataLoader();

    [SerializeField] private float _mapScale = 1;

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

        GameObject tile = Instantiate(_cubePrefab, position, Quaternion.identity, transform);
        tile.GetComponent<MeshRenderer>().material.color = tileData.Color;

        _towerHeights[tileData.Location.x, tileData.Location.y]++;
    }
}
