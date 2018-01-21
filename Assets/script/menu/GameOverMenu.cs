using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    // Use this for initialization
    public void quit()
    {
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
