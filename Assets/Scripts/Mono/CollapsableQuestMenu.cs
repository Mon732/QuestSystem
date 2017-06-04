using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollapsableQuestMenu : CollapsableMenu
{
    string questId;

    public void SetQuestID(string id)
    {
        questId = id;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = questId;
    }

    public string GetQuestID()
    {
        return questId;
    }

    public override void GetProperties()
    {
        base.GetProperties();

        //Set InputField of first property in menu
        properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = questId;

        //Set InputField of second property in menu
        properties.transform.GetChild(1).transform.GetChild(0).GetComponent<InputField>().text = QuestManager.Instance.GetQuest(questId).GetName();

        //Set button text to questId
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = questId;
    }

    public override void SetProperties()
    {
        base.SetProperties();

        string newID = properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text;

        if (QuestManager.Instance.GetQuest(newID) == null)
        {

            QuestManager.Instance.GetQuest(questId).SetID(newID);
            questId = newID;

            //Set button text to questId
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text = questId;

            QuestManager.Instance.GetQuest(questId).SetName(properties.transform.GetChild(1).transform.GetChild(0).GetComponent<InputField>().text);

            list.GenerateList();
        }
        else
        {
            properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = questId.ToString();
        }
    }
}
