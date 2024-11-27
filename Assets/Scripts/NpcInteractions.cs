using UnityEngine;

public class NpcInteractions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Faced(bool faced)
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(faced);
    }
}
