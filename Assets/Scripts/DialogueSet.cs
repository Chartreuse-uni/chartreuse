using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSet : MonoBehaviour
{
    public List<Dialogue> allDialogues;
    public DialogueController dialogueController;
    
    public void Trigger(string dialogueID)
    {
        bool dialogueFound = false;
        Dialogue targetDialogue = allDialogues[0];

        foreach(Dialogue dialogue in allDialogues)
        {
            if(dialogue.dialogueID == dialogueID)
            {
                Debug.Log("found");
                targetDialogue = dialogue;
                dialogueFound = true;
            }
        }

        if(!dialogueFound)
        {
            foreach(Dialogue dialogue in allDialogues)
        {
            if(dialogue.dialogueID == "Default")
            {
                Debug.Log("default dialogue");
                targetDialogue = dialogue;
            }
        }
        }

        dialogueController.InitiateDialogue(targetDialogue);
    }
    
}
