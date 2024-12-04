using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    public DialogueSet temp;
    public DialogueController dialogueController;
    public bool cutsceneInProgress = false;
    public bool playerInControl = false;
    public bool puzzleOneSolved = false;

    private bool tempFlag = false;


    public void SetPlayerControl(bool value)
    {
        playerInControl = value;
    }

    void Update()
    {
            if(cutsceneInProgress && Input.GetKeyDown(KeyCode.F))
            {
                dialogueController.NextSentence();
            }
    }
}
