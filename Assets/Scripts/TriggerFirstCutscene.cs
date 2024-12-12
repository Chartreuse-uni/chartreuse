using UnityEngine;

public class TriggerFirstCutscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public DialogueSet firstLine;
    public StateManager stateManager;

    public void TriggerCutscene()
    {
        firstLine.Trigger("1-1");
        stateManager.playerInDialogue = true;
        this.transform.parent.gameObject.SetActive(false);
    }
}
