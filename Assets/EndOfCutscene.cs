using UnityEngine;

public class EndOfCutscene : MonoBehaviour
{
    public StateManager stateManager;

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
}
