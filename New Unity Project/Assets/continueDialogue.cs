using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueDialogue : MonoBehaviour
{
    public void OnMouseDown()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
