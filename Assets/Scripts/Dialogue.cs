using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string dialogueID;
    public bool triggersEvent;
    public UnityEvent onLastSentence;
    public string characterName;

    [TextArea(3, 10)]
    public string[] allSentences;
}
