using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text scoreText; // Создаете UI текст пустой и прикрепляете сюда.
    
    void Update()
    {
        scoreText.text = "Total score: " + ScoreView.score.ToString(); // Это присваивает вашему тексту значение переменной
    }
}
