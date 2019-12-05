using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4 : MonoBehaviour
{
    public Dialogue dialogue14;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue14);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue14.name = "G";
        dialogue14.sentences = new string[1];
        dialogue14.sentences[0] = "Muahahahaha";

        Invoke("TriggerDialogue", 1);
    }

}
