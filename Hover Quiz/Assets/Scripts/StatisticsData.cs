using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsData : MonoBehaviour
{
    public GameManager gameManager;
    public Score score;

    public float questionAns;
    public float wrongAns;
    public float correctAns;
    public float totalScore;

    public Text ansText;
    public Text wrongText;
    public Text correctText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        questionAns = 0f;
        wrongAns = 0f;
        correctAns = 0f;
        totalScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        questionAns = gameManager.QuestionAnswered;
        wrongAns = gameManager.wrongAns;
        correctAns = gameManager.correctAns;
        totalScore = score.score;


        ansText.text = (int)questionAns + "";
        wrongText.text = (int)wrongAns + "";
        correctText.text = (int)correctAns + "";
        scoreText.text = (int)totalScore + "";
        
    }
}
