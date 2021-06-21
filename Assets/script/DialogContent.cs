using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContent : MonoBehaviour
{
    public Dialogue info;
    private void Start()
    {
        Debug.Log("INFO");
        var system = FindObjectOfType<DialogueSystem1>();
        system.Begin(info);
    }
}
