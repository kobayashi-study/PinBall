using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreRegulator : MonoBehaviour
{
    private int score = 0;
    private string tag;
    private GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "LargeStarTag") {
            score += 20;
        }
        else if (tag == "SmallStarTag") {
            score += 10;
        }
        //ToString("D5")でスコアを10進数表記に変更
        string strScore = score.ToString("D5");
        this.scoreText.GetComponent<Text>().text = "SCORE:" + strScore;
        tag = null;
    }
    private void OnCollisionEnter(Collision other)
    {
        this.tag = other.gameObject.tag;
    }
}
