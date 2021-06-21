using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleRank : MonoBehaviour
{
    public GameObject HIGH;
    public Text HighScore;
    public GameObject[] Rank_BG;
    // Start is called before the first frame update
    void Start()
    {
        int High = PlayerPrefs.GetInt("highScore");
        if (High !=0)
        {
            HIGH.SetActive(true);
            HighScore.text = High.ToString();
            if (High < 1000)
            {
                Rank_BG[0].SetActive(true);//F

            }
            else if (High < 3000)
            {
                Rank_BG[1].SetActive(true);//E

            }
            else if (High < 5000)
            {
                Rank_BG[2].SetActive(true);//D

            }
            else if (High < 6500)
            {
                Rank_BG[3].SetActive(true);//C

            }
            else if (High < 7500)
            {
                Rank_BG[4].SetActive(true);//B

            }
            else if (High < 8500)
            {
                Rank_BG[5].SetActive(true);//A

            }
            else if (High < 9000)
            {
                Rank_BG[6].SetActive(true);//AA

            }
            else if (High < 9500)
            {
                Rank_BG[7].SetActive(true);//AAA

            }
            else if (High < 10000)
            {
                Rank_BG[8].SetActive(true);//S

            }
            else if (High >= 10000)
            {
                Rank_BG[9].SetActive(true);//SS

            }
        }

    }


}
