using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExampleManager : MonoBehaviour
{
    /*References to other game objects*/
    public DialogueController dialogueController;
    public Animator playerAnimator;
    public Rigidbody2D playerBody;
    public GiveHint oracleHint;

    /*References to 'inventory' game objects*/
    public Image inventorySlot;
    public Sprite emptySprite;
    public Sprite ringSprite;

    /*Flags for player state management*/
    public bool playerInDialogue = false;
    public bool playerInControl = false;
    public bool playerInMCQ = false;

    /*Game phases and states*/
    public string phase;
    public string epochState;
    public float hintTimer;

    public bool endOnNextKeyUp = false;



    /*Stops the player instantaneously by setting momentum to 0*/
    public void StopPlayer()
    {
        playerBody.linearVelocity = Vector3.zero;
    }



    /*Manages the flag for dialogue in progress*/
    public void StartDialogue()
    {
        Debug.Log("Dialogue Started");
        StopPlayer();
        playerInDialogue = true;
        playerAnimator.enabled = false;
    }

    public void EndDialogue()
    {
        Debug.Log("Dialogue Ended");
        endOnNextKeyUp = true;
    }



    /*Manages the flag for multiple choice questions in progress*/
    public void StartMCQ()
    {
        Debug.Log("MCQ Started");
        playerInMCQ = true;
    }

    public void EndMCQ()
    {
        Debug.Log("MCQ Ended");
        playerInMCQ = false;
    }



    /*Manages the flag for whether the player has control*/
    public void GivePlayerControl()
    {
        Debug.Log("Control Given to Player");
        playerInControl = true;
    }

    public void TakePlayerControl()
    {
        Debug.Log("Control Taken from Player");
        playerInControl = false;
    }


    /*Manages the progression system and game phases*/
    public void SetPhase(string state)
    {
        phase = state;
        epochState = state;
    }

    public void SetEpochState(string state)
    {
        epochState = state;
    }

    public void ResetEpochState()
    {
        epochState = phase;
    }




    /*Resets hint timer*/
    public void SetHintTimer()
    {
        hintTimer = 20.0f;
    }



    /*Runs once on start up*/
    void Start()
    {
        GivePlayerControl();
        phase = "Initial";
        epochState = "Initial";
        hintTimer = 20.0f;
    }

    /*Runs once per frame*/
    void Update()
    {
        /*Progresses dialogue*/
        if(playerInDialogue && Input.GetKeyDown(KeyCode.F) && !playerInMCQ)
        {
            dialogueController.NextSentence();
        }

        /*Ends dialogue with buffer*/
        if(endOnNextKeyUp && Input.GetKeyUp(KeyCode.F))
        {
            playerInDialogue = false;
            playerAnimator.enabled = true;
            endOnNextKeyUp = false;
        }

        /*Hint timer*/
        if(playerInControl && hintTimer > 0.0f)
        {
            hintTimer -= Time.deltaTime;
        }

        /*Triggers hint when hint timer expires*/
        if(hintTimer <= 0.0f && !playerInDialogue && !playerInMCQ)
        {
            epochState = phase + "-hint";
            //oracleHint.whenClicked();
        }
    }
}
