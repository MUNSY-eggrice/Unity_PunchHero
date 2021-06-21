using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerR : MonoBehaviour
{
   // public bool end2 = false;
    public bool Contact_R = false;
    public static EndTriggerR area;
    public GameObject HIT_UI;

    private void Awake()
    {
       EndTriggerR.area = this;
    }
    private void Update()
    {
        if (Count.Instance.freeze == false)
        {
            if (Contact_R == true)
            {
                Debug.Log("R_cont");
            }
            if (Contact_R == true && Input.GetKeyDown(KeyCode.J))
            {
                // end2 = false;
                Debug.Log("falseR");
                Contact_R = false;
            }
            if (Contact_R == true && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("TRUER");
                HIT_UI.SetActive(true);
                StartCoroutine(HIT());
                ScoreManager.Instance.SCORE -= 200;
               //end2 = true;
            }
        }
    }

    IEnumerator HIT()
    {
        yield return new WaitForSeconds(0.5f);
        HIT_UI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ContactR");
        Contact_R = true;
        EndTriggerL.area.Contact_L = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // end2 = false;
    }
}
