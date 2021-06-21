using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Count : MonoBehaviour
{
    public GameObject Three;
    public GameObject Two;
    public GameObject One;
    public GameObject Go;

    public AudioClip clip;
    public AudioClip goclip;
    public static Count Instance;

    public bool freeze = true;

    [SerializeField] float CountTime = 4.0f;
    private void Start()
    {
        Instance = this;
        Three.SetActive(false);
        Two.SetActive(false);
        One.SetActive(false);
        Go.SetActive(false);
    }
    private void Update()
    {
        
        if (CountTime > 3)
        {
            CountTime -= Time.deltaTime;
            Three.SetActive(true);
        }
        else if (CountTime > 2)
        {
            Three.SetActive(false);
            Two.SetActive(true);
            CountTime -= Time.deltaTime;
            
        }
        else if (CountTime > 1)
        {
            Two.SetActive(false);
            One.SetActive(true);
            CountTime -= Time.deltaTime;
            
        }
        else if (CountTime > 0)  
        {
           
            CountTime -= Time.deltaTime;
            Go.SetActive(true);
            One.SetActive(false);
            freeze = false;
        }
        else
        {
            Go.SetActive(false);
        }
    }

}
