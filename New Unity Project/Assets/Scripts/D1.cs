using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D1 : MonoBehaviour
{
    public Dialogue dialogue11;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue11);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue11.name = "G";
        dialogue11.sentences = new string[2];
        dialogue11.sentences[0] = "Noooo i refuse to pay taxes as I disagree with the institutional powers of the government!a";
        dialogue11.sentences[1] = "Taxation is robbery!!!";

        Invoke("TriggerDialogue", 1);
    }

}
