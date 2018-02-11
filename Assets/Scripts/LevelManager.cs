using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public void loadLevel(string name) {
        Debug.Log("Level load request for " + name);
        SceneManager.LoadScene(name);
        Brick.breakableCount = 0;


    }
    public void quitRequest() {
        Debug.Log("Quit Game Please");
        Application.Quit();
    }
    public void LoadNextLevel() {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed() {
        if (Brick.breakableCount <= 0) {
            LoadNextLevel();
        }

    }


}
