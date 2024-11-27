using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI sentenceText;
    private Queue<string> queuedSentences;
    private GameObject dialogueBox;
    public bool dialogueEnded = true;

    void Start()
    {
        queuedSentences = new Queue<string>();
        dialogueBox = GameObject.FindGameObjectsWithTag("DialogueBox")[0];
        dialogueBox.SetActive(false);
    }

    public void InitiateDialogue(Dialogue currentDialogue)
    {
        dialogueEnded = false;

        queuedSentences.Clear();

        nameText.text = currentDialogue.characterName;

        foreach(string sentence in currentDialogue.allSentences)
        {
            queuedSentences.Enqueue(sentence);
        }

        dialogueBox.SetActive(true);
    }

    public void NextSentence()
    {
        if(queuedSentences.Count == 0) {
            EndDialogue();
            return;
        }

        string currentSentence = queuedSentences.Dequeue();
        sentenceText.text = currentSentence;
    }

    public void EndDialogue()
    {   
        dialogueBox.SetActive(false);

        dialogueEnded = true;

        Debug.Log("Dialogue Ended.");
    }
}
