using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BTNmanager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNtype currenttype;
    public Transform buttonScale;
    public GameObject howto;
    Vector3 defaultScale;
    public AudioClip clip;
    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
    public void OnBTN()
    {
        switch (currenttype)
        {
            case BTNtype.start:
                SoundManager.instance.SFXPlay("Start", clip);
                SceneManager.LoadScene("INGAME");
                
                break;
            case BTNtype.restart:
                SoundManager.instance.SFXPlay("Re", clip);
                gamemanager.instance.IngameMenuTrigger = false;
                Time.timeScale = 1f;
                SceneManager.LoadScene("INGAME");
                break;
            case BTNtype.howto:
                SoundManager.instance.SFXPlay("How", clip);
                howto.SetActive(true);
                break;
            case BTNtype.exit:
                SoundManager.instance.SFXPlay("exit", clip);
                howto.SetActive(false);
                break;
            case BTNtype.mainmenu:
                SoundManager.instance.SFXPlay("Main", clip);
                gamemanager.instance.IngameMenuTrigger = false;
                Time.timeScale = 1f;
                SceneManager.LoadScene("MAINMENU");
                break;
            case BTNtype.ending:
                SoundManager.instance.SFXPlay("END", clip);
                SceneManager.LoadScene("ENDING");
                break;


        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.3f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
