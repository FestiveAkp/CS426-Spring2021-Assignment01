using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int maxScore = 10;

    int score = 0;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void AddPoint()
    {
        score++;
        
        if (score != maxScore)
        {
            scoreText.text = "Score: " + score;
        } 
        else
        {
            scoreText.text = "You won!!!";
        }
    }
}
