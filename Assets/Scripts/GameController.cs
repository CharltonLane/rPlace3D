/*
GameController.cs 

Original Author: Charlton Lane
Created: 
Unity Version: 2021.2.18f1
Contributors: 

Description: 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float _quitGameTimer = 0;
    private float _maxQuitGameTimer = 1.25f;

    [ColorUsageAttribute(true, true)]
    public Color color;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update() {
        ESCToQuit();
        ToggleCursorLock();
        ToggleFullScreen();
    }

    private void ToggleFullScreen() {
        if (Input.GetKeyDown(KeyCode.F11)) {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    private void ToggleCursorLock() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            if (Cursor.lockState == CursorLockMode.Locked) {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void ESCToQuit() {
        if (Input.GetKey(KeyCode.Escape)) {
            _quitGameTimer += Time.deltaTime;
            print(_quitGameTimer);
        }

        if (Input.GetKeyUp(KeyCode.Escape)) {
            _quitGameTimer = 0;
        }

        if (_quitGameTimer >= _maxQuitGameTimer) {
            print("Quitting: " + _quitGameTimer + " " + _maxQuitGameTimer);
            Application.Quit();
        }

    }
}

