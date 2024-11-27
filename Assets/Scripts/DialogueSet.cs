using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSet : MonoBehaviour
{
    public List<Dialogue> allDialogues;
    
    public void Trigger(string dialogueID)
    {
        Dialogue targetDialogue = allDialogues[0];


        foreach(Dialogue dialogue in allDialogues)
        {
            if(dialogue.dialogueID == dialogueID)
            {
                targetDialogue = dialogue;
            }
        }


        Debug.Log(targetDialogue.characterName);

        FindObjectOfType<DialogueController>().InitiateDialogue(targetDialogue);
    }
}
