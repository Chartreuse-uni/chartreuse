using UnityEngine;

public class InRangeOfShopkeep : MonoBehaviour
{
    private bool playerInRange = false;
    private bool playerInDialogue = false;
    public DialogueController dialogueController;

    void Start()
    {
        this.transform.parent.Find("PromptToPlayer").gameObject.SetActive(false);
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if(!playerInDialogue)
            {
                playerInDialogue = true;
                GetComponentInParent<DialogueSet>().Trigger("Puzzle-1");
            }

            else if(playerInDialogue)
            {
                dialogueController.NextSentence();

                if(dialogueController.dialogueEnded)
                {
                    playerInDialogue = false;
                }
            }

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
