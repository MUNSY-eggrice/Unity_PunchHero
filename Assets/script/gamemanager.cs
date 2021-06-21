using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour { 


    public GameObject[] enemy;

    public Transform[] Startspawn_1;
    public Transform[] Startspawn_2;

    public Transform[] SpawnPoint;

    public GameObject IngameMenu;

    public Slider progressbar;
    bool end = false;
    public bool IngameMenuTrigger=false;
    Animation E_anim;
    public static gamemanager instance;
    void Awake()
    {
        StartSpawn();
        StartCoroutine(Timer());
        instance = this;
        E_anim = GetComponent<Animation>();

    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
            while (end == false) {
            yield return null;
            if (progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, 0.03f*Time.deltaTime);
            }
            else if(progressbar.value == 1f)
            {
                end = true;
            }
           }
    }
    private void Update()
    {
        
        GameOver();
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            IngameMenuTrigger = !IngameMenuTrigger;
            IngameMenu.SetActive(IngameMenuTrigger);
            if (IngameMenuTrigger == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
            
    }
    public void StartSpawn()
    {
        int i = 0;
        int ranEnemy;
        //플레이어로 부터 같은 거리에 몬스터가 겹쳐 스폰되지 않게 랜덤으로 스폰하는 코드.
        for(i=0; i<4; i++)
        {
            ranEnemy = Random.Range(0, 2);
            if (ranEnemy == 0)
            {
                Instantiate(enemy[0], Startspawn_1[i].position, Startspawn_1[i].rotation);
            }
            if (ranEnemy == 1)
            {
                Instantiate(enemy[1], Startspawn_2[i].position, Startspawn_2[i].rotation);
            }
        }
    }

    public void EnemySpawn()
    {
        int ranEnemy = Random.Range(0, 2);
        //처음 8개 포지션에 랜덤 소환후, 오른쪽과 왼쪽 끝에서 하나씩 소환.
        // Debug.Log(ranEnemy);
        if (ranEnemy == 0)
        {
            
            Instantiate(enemy[0], SpawnPoint[0].position, SpawnPoint[0].rotation);
        }
        else
        {
            
            Instantiate(enemy[1], SpawnPoint[1].position, SpawnPoint[1].rotation);
        }
    
        //0 left 1 right
        
    }
    
    private void GameOver()
    {
        if (end == true)
        {
            Debug.Log("END!");
            SceneManager.LoadScene("GAMEOVER");
        }
    }

  

 }
