using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerL : MonoBehaviour
{
  //  public bool end = false;
    public bool Contact_L = false;
    public GameObject HIT_UI;

    public static EndTriggerL area;
    private void Awake()
    {
       EndTriggerL.area = this;
    }
    private void Update()
    {
        if (Count.Instance.freeze == false)
        {
            if (Contact_L == true)
            {
                Debug.Log("L_cont");
            }
            if (Contact_L == true && Input.GetKeyDown(KeyCode.F))
            {
                // end = false;
                Debug.Log("falseL");
                Contact_L = false;
            }
            if (Contact_L == true && Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("TRUEL");
                HIT_UI.SetActive(true);
                StartCoroutine(HIT());
                ScoreManager.Instance.SCORE -= 200;
             //   end = true;
            }
        }
    }
    IEnumerator HIT()
    {
        yield return new WaitForSeconds(0.2f);
        HIT_UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ContactL");
        Contact_L = true;
        EndTriggerR.area.Contact_R = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // end = false;
    }
}
