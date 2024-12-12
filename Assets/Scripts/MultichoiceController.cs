using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MultichoiceController : MonoBehaviour
{
    public int correctAnswer;
    public StateManager stateManager;
    public UnityEvent whenCorrect;
    public UnityEvent whenIncorrect;

    void Start()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    public void triggerMultipleChoice()
    {
        this.transform.parent.gameObject.SetActive(true);
        stateManager.StartMCQ();
        stateManager.playerInDialogue = false;
        
    }

    public void answerWith(int answerNumber)
    {
        if(answerNumber == correctAnswer)
        {
            whenCorrect.Invoke();
        }
        else
        {
            whenIncorrect.Invoke();
        }
        this.transform.parent.gameObject.SetActive(false);
        stateManager.EndMCQ();
        stateManager.StartDialogue();
    }
}
