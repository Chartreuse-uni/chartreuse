using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GiveHint : MonoBehaviour
{
    public StateManager stateManager;
    public UnityEvent triggerEpoch;
    public DialogueSet epochDialogue;

    public void whenClicked()
    {
        if(!stateManager.playerInDialogue)
        {
            epochDialogue.Trigger(stateManager.epochState);
            triggerEpoch.Invoke();
            stateManager.TakePlayerControl();
            stateManager.EndMCQ();//
            stateManager.StartDialogue();
        }
    }
}
