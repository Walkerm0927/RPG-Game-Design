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
        dialogue.sentences = new string[6];
        dialogue.sentences[0] = "Muahahahaha";
        dialogue.sentences[1] = "You must be the one they call Greg";
        dialogue.sentences[2] = "You don't stand a chance against my goblin army. But you don't have to perish...";
        dialogue.sentences[3] = "You and I can join forces and together we will never have to fear the IRS again!";
        dialogue.sentences[4] = "No? So be it! I'll watch you die in chains from my throne of freedom";
        dialogue.sentences[5] = "Goblin squad... CHECK HIS VIBE INTO THE AFTERLIFE!";
        Invoke("TriggerDialogue",1);
    }

}
