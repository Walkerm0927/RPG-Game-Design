using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D3 : MonoBehaviour
{
    public Dialogue dialogue13;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue13);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue13.name = "Filthy Tax-Evaders™";
        dialogue13.sentences = new string[2];
        dialogue13.sentences[0] = "Greg please it doesn't have to be like this! Listen the IRS never comes here!! IT'S SAFE";
        dialogue13.sentences[1] = "No Taxes!!!";
        Invoke("TriggerDialogue", 1);
    }

}
