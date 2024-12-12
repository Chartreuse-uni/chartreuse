using UnityEngine;

public class EndOfSoldier : MonoBehaviour
{
    public StateManager stateManager;
    public DialogueController dialogueController;
    public GameObject arguingPair;

    public void onFight()
    {
        stateManager.GivePlayerControl();
        stateManager.EndMCQ();
        stateManager.EndDialogue();
        stateManager.SetPhase("AfterFight");
        this.gameObject.SetActive(false);
    }
}
