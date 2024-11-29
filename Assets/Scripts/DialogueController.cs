using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI sentenceText;
    private Queue<string> queuedSentences;
    private GameObject dialogueBox;
    public bool dialogueEnded = true;
    private bool triggersEvent = false;
    private UnityEvent onLastSentence;

    void Start()
    {
        queuedSentences = new Queue<string>();
        dialogueBox = GameObject.FindGameObjectsWithTag("DialogueBox")[0];
        dialogueBox.SetActive(false);
    }

    public void InitiateDialogue(Dialogue currentDialogue)
    {
        dialogueEnded = false;

        triggersEvent = currentDialogue.triggersEvent;

        if(triggersEvent)
        {
            onLastSentence = currentDialogue.onLastSentence;
        }

        queuedSentences.Clear();

        nameText.text = currentDialogue.characterName;

        foreach(string sentence in currentDialogue.allSentences)
        {
            queuedSentences.Enqueue(sentence);
        }

        NextSentence();

        dialogueBox.SetActive(true);
    }

    public void NextSentence()
    {
        if(queuedSentences.Count == 0) {
            EndDialogue();
            return;
        }

        if(queuedSentences.Count == 1 && triggersEvent) {
            Debug.Log("lol Im Here");
            onLastSentence.Invoke();
        }

        string currentSentence = queuedSentences.Dequeue();
        sentenceText.text = currentSentence;
    }

    public void EndDialogue()
    {   
        dialogueBox.SetActive(false);

        dialogueEnded = true;
    }
}
