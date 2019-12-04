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


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogue)
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue d)
    {
        dialogue = true;
        anim.SetBool("dialogue", true);
        nametext.text = d.name;
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
        string sentence = sentences.Dequeue();
        dialoguetext.text = sentence;
    }

    public void EndDialogue()
    {
        dialogue = false;
        anim.SetBool("dialogue", false);
        FindObjectOfType<PlayerController>().dialogue = false;
        sentences.Clear();
    }

    public void OnMouseDown()
    {
        if (dialogue)
        {
            DisplayNextSentence();
        }
    }
}
