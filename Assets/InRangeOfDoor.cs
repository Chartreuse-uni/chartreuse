using UnityEngine;

public class InRangeOfDoors : MonoBehaviour
{
    public Vector2 teleportLocation;
    private bool playerInRange = false;

    void Start()
    {
        this.transform.parent.Find("PromptToPlayer").gameObject.SetActive(false);
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            GameObject.FindGameObjectsWithTag("Player")[0].transform.position = new Vector3(teleportLocation.x, teleportLocation.y, 0);
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
