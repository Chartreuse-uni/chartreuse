using UnityEngine;

public class InRange : MonoBehaviour
{
    private bool playerInRange = false;
    private bool playerInDialogue = false;
    private DialogueController dialogueController;

    void Start()
    {
        this.transform.parent.Find("TextBox").gameObject.SetActive(false);
        dialogueController = FindObjectOfType<DialogueController>();
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if(!playerInDialogue)
            {
                playerInDialogue = true;
                GetComponentInParent<DialogueSet>().Trigger("idle");
            }

            if(playerInDialogue)
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
            this.transform.parent.Find("TextBox").gameObject.SetActive(true);
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.transform.parent.Find("TextBox").gameObject.SetActive(false);
            playerInRange = false;
        }
    }
}
