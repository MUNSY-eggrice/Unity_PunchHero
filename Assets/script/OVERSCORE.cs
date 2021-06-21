using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OVERSCORE : MonoBehaviour
{
    public Text Score;
    public Text HighScore;
    public GameObject[] Rank_BG;
    public AudioClip[] Rank_Sound;
    AudioSource audio;
    private void Awake()
    {
        audio = gameObject.AddComponent<AudioSource>();
        Score.text = ScoreManager.Instance.SCORE.ToString();
        HighScore.text = ScoreManager.Instance.HIGHSCORE.ToString();
        if(ScoreManager.Instance.SCORE < 1000)
        {
            Rank_BG[0].SetActive(true);//F
            audio.clip = Rank_Sound[0];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 3000)
        {
            Rank_BG[1].SetActive(true);//E
            audio.clip = Rank_Sound[0];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 5000)
        {
            Rank_BG[2].SetActive(true);//D
            audio.clip = Rank_Sound[0];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 6500)
        {
            Rank_BG[3].SetActive(true);//C
            audio.clip = Rank_Sound[1];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 7500)
        {
            Rank_BG[4].SetActive(true);//B
            audio.clip = Rank_Sound[1];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 8500)
        {
            Rank_BG[5].SetActive(true);//A
            audio.clip = Rank_Sound[1];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 9000)
        {
            Rank_BG[6].SetActive(true);//AA
            audio.clip = Rank_Sound[2];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 9500)
        {
            Rank_BG[7].SetActive(true);//AAA
            audio.clip = Rank_Sound[2];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE < 10000)
        {
            Rank_BG[8].SetActive(true);//S
            audio.clip = Rank_Sound[2];
            audio.Play();
        }
        else if(ScoreManager.Instance.SCORE >= 10000)
        {
            Rank_BG[9].SetActive(true);//SS
            audio.clip = Rank_Sound[3];
            audio.Play();
        }

    }

}
