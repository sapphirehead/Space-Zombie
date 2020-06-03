using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ScreenSwitching()
    {
        SceneManager.LoadScene("SpaceGame");
        ScoreView.score = 0;
        PlayerControls.playerLives = 5;
    }
}
