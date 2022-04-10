/*
SimpleHUD.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHUD : MonoBehaviour {


    [SerializeField] private GameObject _canvas1;
    [SerializeField] private GameObject _canvas2;

    [SerializeField] private GameObject _quitCanvas;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            _canvas1.SetActive(!_canvas1.activeSelf);
            _canvas2.SetActive(!_canvas2.activeSelf);
        }


        _quitCanvas.SetActive(Input.GetKey(KeyCode.Escape));

    }
}

