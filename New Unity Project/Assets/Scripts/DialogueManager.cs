using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool dialogue;
    public Animator anim;
    void Start()
    {
        dialogue = false;
    }
    
    public void StartDialogue()
    {
        dialogue = true;
        anim.SetBool("dialogue", true);
    }

    public void EndDialogue()
    {
        dialogue = false;
        anim.SetBool("dialogue", false);
    }
}
