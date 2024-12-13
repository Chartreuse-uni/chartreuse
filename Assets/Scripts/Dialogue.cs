using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string dialogueID;
    public bool triggersEvent;
    public UnityEvent onStart;
    public UnityEvent onLastSentence;
    public UnityEvent onEnd;
    public string characterName;
    public Sprite characterSprite;

    [TextArea(3, 10)]
    public string[] allSentences;
}

