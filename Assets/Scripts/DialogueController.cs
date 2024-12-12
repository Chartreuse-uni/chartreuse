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
    public Image characterPortrait;
    private Queue<string> queuedSentences;
    private GameObject dialogueBox;
    public bool dialogueEnded = true;
    private bool triggersEvent = false;
    private UnityEvent onLastSentence;
    private UnityEvent onEnd;

    void Start()
    {
        queuedSentences = new Queue<string>();
        dialogueBox = GameObject.FindGameObjectsWithTag("Dialogue")[0];
        dialogueBox.SetActive(false);
    }

    public void InitiateDialogue(Dialogue currentDialogue)
    {
        dialogueEnded = false;

        triggersEvent = currentDialogue.triggersEvent;

        if(triggersEvent)
        {
            onLastSentence = currentDialogue.onLastSentence;
            onEnd = currentDialogue.onEnd;
        }

        queuedSentences.Clear();

        characterPortrait.sprite = currentDialogue.characterSprite;

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

            if(triggersEvent)
            {
                onEnd.Invoke();
            }
            return;
        }

        if(queuedSentences.Count == 1 && triggersEvent) {
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
