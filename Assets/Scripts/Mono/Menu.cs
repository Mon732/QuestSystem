using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject expandedMenu;

    bool isOpen;

	// Use this for initialization
	void Start ()
    {
        HideMenu();
	}

    public void ToggleMenu()
    {
        if (isOpen)
        {
            HideMenu();
        }
        else
        {
            ShowMenu();
        }
    }

    public void ShowMenu()
    {
        isOpen = true;
        expandedMenu.SetActive(isOpen);
    }

    public void HideMenu()
    {
        isOpen = false;
        expandedMenu.SetActive(isOpen);
    }

    public void Load()
    {

    }

    public void Save()
    {
        QuestManager.Instance.Save("quests.xml");
    }
}
