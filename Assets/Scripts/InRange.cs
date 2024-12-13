using UnityEngine;

public class InRange : MonoBehaviour
{
    private bool playerInRange = false;
    public StateManager stateManager;
    public DialogueController dialogueController;

    void Start()
    {
        this.transform.parent.Find("PromptToPlayer").gameObject.SetActive(false);
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.F) && !stateManager.playerInDialogue && !stateManager.playerInMCQ)
        {
            GetComponentInParent<DialogueSet>().Trigger(stateManager.phase);
            stateManager.TakePlayerControl();
        }

        if(playerInRange && Input.GetKeyUp(KeyCode.F) && !stateManager.playerInDialogue && !stateManager.playerInMCQ)
        {
            stateManager.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.transform.parent.Find("PromptToPlayer").gameObject.SetActive(true);
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.transform.parent.Find("PromptToPlayer").gameObject.SetActive(false);
            playerInRange = false;
        }
    }
}
