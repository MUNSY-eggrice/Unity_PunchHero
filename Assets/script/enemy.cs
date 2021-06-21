using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    Animator anim;
    bool Diecount = false;
    camerashake Camera;
    public AudioClip clip;
    public AudioClip scoreclip;
    bool MoveCount = true;
    bool ScoreConut = true;
    private void Awake()
    {
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<camerashake>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (gamemanager.instance.IngameMenuTrigger == false)
        {
            if (Count.Instance.freeze == false)
            {

                if (Diecount == true && Input.GetKeyDown(KeyCode.F))
                {
                    MoveCount = false;
                    
                    anim.SetTrigger("EDIE");
                    if (ScoreConut==true)
                    {
                        ScoreManager.Instance.SCORE += 50;
                    }
                    ScoreConut = false;
                    Invoke("Destroy", 0.3f);
                    ScoreSound();
                }
                if (MoveCount == true)
                {
                    Move();
                }
            }
        }
        
    }

    void Destroy()
    {
        Destroy(gameObject);
        Debug.Log("Des");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            SoundManager.instance.SFXPlay("DIE",clip);
            Camera.VibrateForTime(0.05f);
            Destroy(gameObject);
        }
        else
        {
            Diecount = true;
        }
    }
    
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
        {
            Vector3 vec = new Vector3(2, 0, 0);
            transform.Translate(vec);
        }

    }

    void ScoreSound()
    {
        for(int i=1; i<12; i++)
        {
            if (ScoreManager.Instance.SCORE == 1000*i)
                SoundManager.instance.SFXPlay("Score", scoreclip);
        }
        
    }
}
