using UnityEngine;

public class InRangeOfShopkeep : MonoBehaviour
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
        if(playerInRange && Input.GetKeyDown(KeyCode.F) && !stateManager.playerInDialogue)
        {
            GetComponentInParent<DialogueSet>().Trigger("Puzzle-1");
            stateManager.TakePlayerControl();
        }

        if(playerInRange && Input.GetKeyUp(KeyCode.F) && !stateManager.playerInDialogue)
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
