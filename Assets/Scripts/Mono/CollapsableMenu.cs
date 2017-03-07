using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollapsableMenu : MonoBehaviour
{
    public GameObject properties;
    public CollapsableList list;

    public Color normalColour;
    public Color selectedColour;

    public bool isSelected;
    public bool isOpen;

    string questId;

    // Use this for initialization
    void Start()
    {
        properties.SetActive(false);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetQuestID(string id)
    {
        questId = id;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = questId;
    }

    public void ToggleSelect()
    {
        if (isSelected)
        {
            Deselect();
        }
        else
        {
            Select();
        }
    }

    public void Select()
    {
        list.Select(gameObject);
        isSelected = true;
        transform.GetChild(0).GetComponent<Image>().color = selectedColour;
    }

    public void Deselect()
    {
        list.Deselect();
        isSelected = false;
        transform.GetChild(0).GetComponent<Image>().color = normalColour;
    }

    public void ToggleProperties()
    {
        if (isOpen)
        {
            HideProperties();
        }
        else
        {
            ShowProperties();
        }
    }

    public void ShowProperties()
    {
        properties.SetActive(true);
        isOpen = true;
        GetProperties();

        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "-";

        list.AlignList();
    }

    public void HideProperties()
    {
        properties.SetActive(false);
        isOpen = false;

        transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "+";

        list.AlignList();
    }

    public void GetProperties()
    {
        properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = questId;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = questId;

        properties.transform.GetChild(1).transform.GetChild(0).GetComponent<InputField>().text = QuestManager.Instance.GetQuest(questId).GetName();
    }

    public void SetProperties()
    {
        string newID = properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text;

        QuestManager.Instance.GetQuest(questId).SetID(newID);
        questId = newID;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = questId;

        QuestManager.Instance.GetQuest(questId).SetName(properties.transform.GetChild(1).transform.GetChild(0).GetComponent<InputField>().text);
    }
}
