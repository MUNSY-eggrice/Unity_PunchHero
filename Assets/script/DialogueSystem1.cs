using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueSystem1 : MonoBehaviour
{
    
    public Text txtName;
    public Text txtSentence;
    public Animator imganim;
    AudioSource aud;
    int count = 0;
   

    Queue<string> sentences = new Queue<string>();

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Begin(Dialogue info)
    {
        sentences.Clear();
        txtName.text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Debug.Log("begin");
        Next();
    }

    public void Next()
    { 
        count++;
        if(count == 3)
        {
            imganim.SetBool("IsIMAGE", true);
        }
        if (sentences.Count == 0)
        {
            End();
            return;
        }
        txtSentence.text = string.Empty;
        aud.Stop();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
        aud.Play();
        Debug.Log("Once");
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void End()
    {
        Debug.Log("END!");
        SceneManager.LoadScene("MAINMENU");
        txtSentence.text = string.Empty;
    }
}
