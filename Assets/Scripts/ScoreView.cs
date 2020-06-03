using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public static int score = 0;
    void OnGUI()
    {
        GUIStyle styleTime = new GUIStyle
        {
            fontSize = 20 
        };
        styleTime.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score, styleTime);
        //GUI.Label(new Rect(Screen.width - 130, 10, 100, 20), "Lives: " + PlayerControls.playerLives, styleTime);
        GUI.Label(new Rect(Screen.width - 80, 10, 100, 20), "Lives: " + PlayerControls.playerLives, styleTime);// andr
    }
}
