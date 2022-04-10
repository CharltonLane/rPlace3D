/*
MinimapCamera.cs 

Original Author: Charlton Lane
Created: 10/04/2022
Unity Version: 2021.2.18f1
Contributors: 

Description: Controls the minimap camera. Moves it to the correct position, zooms it in/out and show/hides it.
*/


using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    [SerializeField] private Transform _followTransform;
    [SerializeField] private Camera _camera;

    // Camera zoom parameters.
    private readonly float _maxZoom = 24;
    private readonly float _minZoom = 1;
    private readonly float _zoomSensitiviy = 30;
    private float _currentZoom = 10;


    void Update() {

        // Show/Hide the minimap.
        if (Input.GetKeyDown(KeyCode.M)) {
            _camera.enabled = !_camera.enabled;
        }

        // Move the camera to the correct location.
        transform.position = new Vector3(_followTransform.position.x, 1000, _followTransform.position.z);

        // Minimap zooming.
        _currentZoom -= Input.mouseScrollDelta.y * Time.deltaTime * _zoomSensitiviy;
        _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);
        _camera.orthographicSize = _currentZoom;
    }
}

