using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public bool isHighScore;

    float highScore;
    Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
        
        if(isHighScore)
        {
            highScore = PlayerPrefs.GetFloat("Score");
            uiText.text = highScore.ToString("F0");
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.isLive)
            return;

        if (isHighScore && GameManager.score < highScore)
            return;

        uiText.text = GameManager.score.ToString("F0");
    }
}
