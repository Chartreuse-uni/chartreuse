using UnityEngine;
using UnityEngine.Playables;

public class EndDemo : MonoBehaviour
{
    public PlayableDirector finalCutscene;
    public StateManager stateManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            stateManager.TakePlayerControl();
            this.gameObject.SetActive(false);
            finalCutscene.Play();
        }
    }
}
