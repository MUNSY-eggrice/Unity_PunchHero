using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    AudioSource audSource;
    Animator anim;
    camerashake Camera;
    public gamemanager GameManager;
    public AudioClip[] clip;
    public AudioClip bgclip;
    AudioSource bg;
    bool bgtrigger;
    // Start is called before the first frame update
    void Awake()
    {
        bgtrigger = true;
        bg = gameObject.AddComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<camerashake>();
        
    }
    /*
    void rightRayhit()
    {
        Vector2 rightVec = new Vector2(transform.position.x + 1, transform.position.y);
        Debug.DrawRay(rightVec, Vector3.right, new Color(0, 1, 0));
        RaycastHit2D rayhit2 = Physics2D.Raycast(rightVec, Vector3.right, 1);
        if (rayhit2.collider.tag == "enemy2" && Input.GetKeyDown(KeyCode.H))
        {
            enemy2.Ondamaged();
        }
        else if (rayhit2.collider.tag == "enemy2" && Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 0f;
        }
    }
    void leftRayhit()
    {
        
        Vector2 leftVec = new Vector2(transform.position.x - 1, transform.position.y);

        //Raycast
        

        Debug.DrawRay(leftVec, Vector3.left, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(leftVec, Vector3.left, 1);

        //left punch to enemy
        if (rayhit.collider.tag == "enemy" && Input.GetKeyDown(KeyCode.D))
        {
            enemy.Ondamaged();
        }
        else if (rayhit.collider.tag == "enemy" && Input.GetKeyDown(KeyCode.H))
        {
            Time.timeScale = 0f;
        }

        //right punch to enemy2
       

    }
    */
    
// Update is called once per frame
void Update()
    {
        if (gamemanager.instance.IngameMenuTrigger == false)
        {
            if (Count.Instance.freeze == false)
            {
                if (bgtrigger == true)
                {
                    bg.clip = bgclip;
                    bg.volume = 0.7f;
                    bg.Play();
                    Debug.Log("BGM");
                }

                if (Input.GetKeyDown(KeyCode.F))
                {

                    int i = Random.Range(0, 2);
                    spriteRenderer.flipX = false;
                    SoundManager.instance.SFXPlay("Lpunch", clip[i]);
                    if (i == 0)
                    {
                        anim.SetTrigger("Punch");

                    }
                    else
                    {
                        anim.SetTrigger("Punch2");
                    }
                    Camera.VibrateForTime(0.02f);
                    GameManager.EnemySpawn();
                }
                if (Input.GetKeyDown(KeyCode.J))
                {

                    int i = Random.Range(0, 2);
                    spriteRenderer.flipX = true;
                    SoundManager.instance.SFXPlay("Rpunch", clip[i]);
                    if (i == 0)
                    {
                        anim.SetTrigger("Punch");

                    }
                    else
                    {
                        anim.SetTrigger("Punch2");
                    }
                    Camera.VibrateForTime(0.02f);
                    GameManager.EnemySpawn();
                }
                bgtrigger = false;
            }
        }
        else
        {
            bg.Pause();
            bgtrigger = true;
        }
    }

}