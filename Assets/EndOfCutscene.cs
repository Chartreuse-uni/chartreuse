using UnityEngine;

public class EndOfCutscene : MonoBehaviour
{
    public StateManager stateManager;
    public DialogueSet gunman;
    public DialogueSet traveller;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void EndCrowd()
    {
        Debug.Log("Ending crowd cutscene");
        stateManager.GivePlayerControl();
        stateManager.SetPhase("AfterRing");
        stateManager.EndMCQ();
        this.gameObject.SetActive(false);
    }

    public void EndSoldier()
    {
        Debug.Log("Ending soldier cutscene");
        stateManager.GivePlayerControl();
        stateManager.EndMCQ();
        stateManager.EndDialogue();
        stateManager.SetPhase("AfterFight");
        this.gameObject.SetActive(false);
    }

    public void EndDuke()
    {
        Debug.Log("Ending duke cutscene");
        stateManager.EndMCQ();
        stateManager.StartDialogue();
        gunman.Trigger("6-1");
        this.gameObject.SetActive(false);
    }

    public void EndGunman()
    {
        Debug.Log("Ending gunman cutscene");
        stateManager.EndMCQ();
        stateManager.StartDialogue();
        traveller.Trigger("6-2");
        this.gameObject.SetActive(false);
    }

    public void DropTimeCore()
    {
        stateManager.DropTimeCore();
    }
}
