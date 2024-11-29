using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Questlog : MonoBehaviour
{
    [SerializeField]
    private GameObject questPrefab;

    [SerializeField]
    private Transform questParent;

    private Quest selected;

    [SerializeField]
    private TextMeshProUGUI questDescription;

    private static Questlog instance;

    public static Questlog MyInstance
    {
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Questlog>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AcceptQuest(Quest quest)
    {
        GameObject go = Instantiate(questPrefab, questParent);

        QuestScript qs = go.GetComponent<QuestScript>();
        quest.MyQuestScript = qs;
        qs.MyQuest = quest;


        go.GetComponent<TextMeshProUGUI>().text = quest.MyTitle;


    }

    public void ShowDescription(Quest quest)
    {
        if (selected != null)
        {
            selected.MyQuestScript.DeSelect();
        }

        string objectives = string.Empty;

        selected = quest;

        string title = quest.MyTitle;

        foreach (Objective obj in quest.MyCollectObjectives)
        {
            objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
        }

        questDescription.text = string.Format("<b>{0}</b>\n\n<color=yellow>Objectives</color>\n{1}",title, quest.MyDescription);

    }
    


}