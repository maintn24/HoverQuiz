using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public float pointIncreasePerSec;
    public bool isEnded = false;

    private void Start()
    {
        score = 0f;
        pointIncreasePerSec = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnded==false)
        {
            scoreText.text = (int)score + "";
            score += pointIncreasePerSec * Time.deltaTime;
        }
        else
        {
            scoreText.text = (int)score + "";
        }
            

    }
}
