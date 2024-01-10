using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieGameEndScore : MonoBehaviour
{
    public Text endScore;
    public ScoreData scoreData;
    public GameManager manager;
    public bool isUI;
    // Start is called before the first frame update
    void Start()
    {
        isUI = false;
        endScore = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (manager.isGameOver = true && isUI == false)
        {
            isUI = true;
            EndScore();
        }
    }

    void EndScore()
    {
        if (scoreData.score >= 100)
            scoreData.score -= 100;
        string str = scoreData.ScoreCount();
        endScore.text = str;
    }
}
