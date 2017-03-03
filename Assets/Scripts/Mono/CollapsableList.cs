using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsableList : MonoBehaviour
{
    public GameObject menuItem;
    public int closedOffset;
    public int openOffset;

    List<GameObject> menuItems;
    RectTransform rectTransform;

	// Use this for initialization
	void Start ()
    {
        rectTransform = GetComponent<RectTransform>();

        GenerateList();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void GenerateList()
    {
        Debug.Log("Generating List");

        menuItems = new List<GameObject>();

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject item = Instantiate(menuItem, transform, false);
            CollapsableMenu menu = item.GetComponent<CollapsableMenu>();

            item.transform.SetAsLastSibling();
            menu.list = this;
            menuItems.Add(item);
            menu.SetQuestID(QuestManager.Instance.GetQuest(i).GetID());

            AlignList();

            /*if (menu.isOpen)
            {
                item.transform.localPosition += new Vector3(0, openOffset * i, 0);
            }
            else
            {
                item.transform.localPosition += new Vector3(0, closedOffset * i, 0);
            }*/
        }
    }

    public void AlignList()
    {
        bool shiftDown = false;

        int listHeight = 0;

        for (int i = 0; i < menuItems.Count; i++)
        {
            CollapsableMenu menu = menuItems[i].GetComponent<CollapsableMenu>();

            if (i > 0)
            {
                Vector3 pos = menuItems[i - 1].transform.localPosition;

                if (shiftDown)
                {
                    menuItems[i].transform.localPosition = pos + new Vector3(0, openOffset, 0);
                    shiftDown = false;
                }
                else
                {
                    menuItems[i].transform.localPosition = pos + new Vector3(0, closedOffset, 0);
                }
            }

            if (menu.isOpen)
            {
                shiftDown = true;
                listHeight += openOffset;
            }
            else
            {
                listHeight += closedOffset;
            }
        }

        listHeight = Mathf.Abs(listHeight);

        //Debug.Log("List Height: " + listHeight);

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, listHeight);
    }

    public void DeselectList()
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            CollapsableMenu menu =  menuItems[i].GetComponent<CollapsableMenu>();
            menu.Deselect();
        }
    }
}
