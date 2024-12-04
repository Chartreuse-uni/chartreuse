using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    public DialogueSet temp;
    public DialogueController dialogueController;
    public bool playerInControl = false;
    public bool puzzleOneSolved = false;

    private bool tempFlag = false;


    public void EnablePlayerControl(bool value)
    {
        playerInControl = value;
    }


    void Start()
    {
        
    }

    void Update()
    {
        if(!tempFlag && Input.GetKeyDown(KeyCode.F))
        {
            temp.Trigger("1-1");
            tempFlag = true;
        }
        else
        {
            if(tempFlag && Input.GetKeyDown(KeyCode.F))
            {
                dialogueController.NextSentence();
            }

        }
        
    }
}
