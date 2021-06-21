using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDING : MonoBehaviour
{
    public GameObject end;

    void Update()
    {
        if(ScoreManager.Instance.SCORE >= 10000)
        {
            end.SetActive(true);
        }
    }
}
