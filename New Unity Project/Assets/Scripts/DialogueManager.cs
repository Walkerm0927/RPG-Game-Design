using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text nametext;
    public Text dialoguetext;
    public bool dialogue;
    public Animator anim;

    private Queue<string> sentences;
    void Start()
    {
        dialogue = false;
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue d)
    {
        dialogue = true;
        anim.SetBool("dialogue", true);

        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
    }

    public void EndDialogue()
    {
        dialogue = false;
        anim.SetBool("dialogue", false);
    }
}
