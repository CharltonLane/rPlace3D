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

public class MinimapCameraPositionUpdater : MonoBehaviour {

    [SerializeField] private Transform _parent;
    [SerializeField] private Camera _camera;

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            _camera.enabled = !_camera.enabled;
        }

        transform.position = new Vector3(_parent.position.x, 1000, _parent.position.z);
    }
}

