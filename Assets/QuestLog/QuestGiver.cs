using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestGiver : MonoBehaviour
{

    [SerializeField]
    private Quest[] quests;

    //Debugging 
    [SerializeField]
    private Questlog tmpLog;


    private void Awake()
    {
        //Here we need to accept a quest // Debugging only
        tmpLog.AcceptQuest(quests[0]);
        //tmpLog.AcceptQuest(quests[1]);
    }


}