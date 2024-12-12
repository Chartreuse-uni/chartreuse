using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class StateManager : MonoBehaviour
{
    public DialogueController dialogueController;
    public Animator playerAnimator;
    public Rigidbody2D playerBody;
    public GiveHint oracleHint;
    public PlayableDirector crowdCutscene;
    public PlayableDirector soldierCutscene;//
    public GameObject blackScreen;

    public bool playerInDialogue = false;
    public bool playerInControl = false;
    public bool playerInMCQ = false;
    public bool puzzleOneSolved = false;
    public string phase;
    public string epochState;
    public float hintTimer;

    public bool endOnNextKeyUp = false;

    public void StopPlayer()
    {
        playerBody.linearVelocity = Vector3.zero;
    }

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

    public void SetPhase(string state)
    {
        phase = state;
        epochState = state;
    }

    public void SetEpochState(string state)
    {
        epochState = state;
    }

    public void SetHintTimer()
    {
        hintTimer = 20.0f; /*test value hello*/
    }

    public void ClearCouple()
    {
        blackScreen.SetActive(true);
        crowdCutscene.Play();
    }

    public void ClearSoldier()
    {
        blackScreen.SetActive(true);
        soldierCutscene.Play();
    }

    void Start()
    {
        TakePlayerControl();
        phase = "Initial";
        epochState = "Initial";
        hintTimer = 20.0f; /*test value*/
    }

    void Update()
    {
            if(playerInDialogue && Input.GetKeyDown(KeyCode.F))
            {
                dialogueController.NextSentence();
            }

            if(endOnNextKeyUp && Input.GetKeyUp(KeyCode.F))
            {
                playerInDialogue = false;
                playerAnimator.enabled = true;
                endOnNextKeyUp = false;
            }

            if(playerInControl && hintTimer > 0.0f)
            {
                hintTimer -= Time.deltaTime;
            }

            if(hintTimer <= 0.0f && !playerInDialogue && !playerInMCQ)
            {
                epochState = phase + "-hint";
                oracleHint.whenClicked();
            }
    }
}
