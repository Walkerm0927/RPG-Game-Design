using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D2 : MonoBehaviour
{
    public Dialogue dialogue12;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue12);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue12.name = "Nontaxpayers";
        dialogue12.sentences = new string[1];
        dialogue12.sentences[0] = "Stop this we claimed this property we are allowed to chase after you and attack in self defense!!!";

        Invoke("TriggerDialogue", 1);
    }

}
