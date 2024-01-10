using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreData : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
    }
    public string ScoreCount()
    {
        score += 100;
        scoreText.text = score.ToString();
        return scoreText.text;
    }
}
