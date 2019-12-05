using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBeg : MonoBehaviour
{
    public Dialogue dialogue1;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue1);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue1.name = "";
        dialogue1.sentences = new string[5];
        dialogue1.sentences[0] = "After the 08 AD recession countess  Lily-pudding was in dire straights as her home got repossessed by the bank after she failed to pay her mortgage.";
        dialogue1.sentences[1] = "She now seeks open property and goes with her lawyer friend the great and magnificent Greg™ to an open castle.";
        dialogue1.sentences[2] = "But suddenly they are attacked by monsters squatting in the castle so that they can commit tax evasion";
        dialogue1.sentences[3] = "Seeing his chance the great and magnificent Greg™ goes into action on those filthy non-taxpayers";
        dialogue1.sentences[4] = "Use wasd to move space to attack and e to interact";
        
        Invoke("TriggerDialogue", 1);
    }

}
