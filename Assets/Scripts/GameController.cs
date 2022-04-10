/*
GameController.cs 

Original Author: Charlton Lane
Created: 10/04/2022
Unity Version: 2021.2.18f1
Contributors: 

Description: Script that adds many basic functions to the program.
*/


using UnityEngine;

public class GameController : MonoBehaviour {

    // Timer variables used to see if the app should be closed.
    private float _quitGameTimer = 0;
    private float _maxQuitGameTimer = 1.25f;


    private void Update() {
        ESCToQuit();
        ToggleFullScreen();
    }


    private void ToggleFullScreen() {
        // F11 to toggle fullscreen.
        if (Input.GetKeyDown(KeyCode.F11)) {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }


    private void ESCToQuit() {
        // Listens for ESC being held for some time, then closes the program.

        if (Input.GetKey(KeyCode.Escape)) {
            _quitGameTimer += Time.deltaTime;
            print(_quitGameTimer);
        }

        if (Input.GetKeyUp(KeyCode.Escape)) {
            _quitGameTimer = 0;
        }

        if (_quitGameTimer >= _maxQuitGameTimer) {
            Application.Quit();
        }

    }
}

