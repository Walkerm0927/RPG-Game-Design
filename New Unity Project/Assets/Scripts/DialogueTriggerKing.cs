using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerKing : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue.name = "Goblin King";
        dialogue.sentences = new string[4];
        dialogue.sentences[0] = "Muahahahaha";
        dialogue.sentences[1] = "You must be the one they call Greg";
        dialogue.sentences[2] = "You don't stand a chance against my goblin army.";
        dialogue.sentences[3] = "Minions... ATTACK!";
        Invoke("TriggerDialogue",1);
    }

}
