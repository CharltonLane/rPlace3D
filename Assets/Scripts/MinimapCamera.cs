/*
LockRotation.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    [SerializeField] private Transform _parent;
    [SerializeField] private Camera _camera;
    private float _maxZoom = 24;
    private float _minZoom = 1;
    private float _currentZoom = 10;
    private float _zoomSensitiviy = 30;

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            _camera.enabled = !_camera.enabled;
        }

        transform.position = new Vector3(_parent.position.x, 1000, _parent.position.z);

        // Minimap zooming.
        _currentZoom -= Input.mouseScrollDelta.y * Time.deltaTime * _zoomSensitiviy;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);
        _camera.orthographicSize = _currentZoom;
    }
}

