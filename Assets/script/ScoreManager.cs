using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text Scoretext;
    int score;

    public int SCORE
    {
        get { return score; }
        set
        {
            score = value;
            if(score < 0)
            {
                score = 0;
            }
            Scoretext.text = score.ToString();
           
            if(score > highScore)
            {
                HIGHSCORE = score;
                PlayerPrefs.SetInt("highScore", highScore);
            }
        }
    }

    public Text highScoreText;
    int highScore;

    public int HIGHSCORE
    {
        get { return highScore; }
        set
        {
            highScore = value;
            highScoreText.text = highScore.ToString();
        }
    }

    void Start()
    {
        HIGHSCORE = PlayerPrefs.GetInt("highScore",0);
 
        Instance = this;
    }

    void Update()
    {
        
    }
}
