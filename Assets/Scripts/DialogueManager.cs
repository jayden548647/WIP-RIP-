using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Animator animator;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialoguePortrait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
        dialoguePortrait = GameObject.FindGameObjectWithTag("DialoguePortrait");
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("dialogue", true);
        Debug.Log("Starting Dialogue");
        nameText.text = dialogue.name;
        if (dialogue.name == "PC")
        {
            dialoguePortrait.SetActive(false);
        }
        if (dialogue.name == "Cameila")
        {
            dialoguePortrait.SetActive(true);
        }
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        MusicManager.instance.PlaySFX("Dialogue");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Dialogue");
        animator.SetBool("dialogue", false);
    }
}
