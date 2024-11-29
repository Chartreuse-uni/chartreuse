using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuestOnOff : MonoBehaviour
{

    public GameObject QuestLog;
    private bool menuActivated;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("QuestLog") && menuActivated)
        {
            Time.timeScale = 1;
            QuestLog.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("QuestLog") && !menuActivated)
        {
            Time.timeScale = 0;
            QuestLog.SetActive(true);
            menuActivated = true;
        }
    }



}