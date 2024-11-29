using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSet : MonoBehaviour
{
    public List<Dialogue> allDialogues;
    public DialogueController dialogueController;
    
    public void Trigger(string dialogueID)
    {
        Dialogue targetDialogue = allDialogues[0];

        Debug.Log(targetDialogue.characterName);


        foreach(Dialogue dialogue in allDialogues)
        {
            if(dialogue.dialogueID == dialogueID)
            {
                targetDialogue = dialogue;
            }
        }

        Debug.Log(targetDialogue.characterName);

        dialogueController.InitiateDialogue(targetDialogue);
    }
}
