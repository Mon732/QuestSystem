using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollapsableList : MonoBehaviour
{
    public GameObject menuItem;
    public int closedOffset;
    public int openOffset;
    public GameObject selectedItem;

    protected List<GameObject> menuItems;
    protected RectTransform rectTransform;

    // Use this for initialization
    protected virtual void Start ()
    {
        rectTransform = GetComponent<RectTransform>();

        GenerateList();
	}

    public virtual void GenerateList()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        menuItems = new List<GameObject>();
    }

    public void AlignList()
    {
        bool shiftDown = false;

        int listHeight = 0;

        for (int i = 0; i < menuItems.Count; i++)
        {
            CollapsableMenu menu = menuItems[i].GetComponent<CollapsableMenu>();

            if (i == 0)
            {
                menuItems[i].transform.localPosition = new Vector3(rectTransform.rect.width/2, 0, 0);
            }
            else
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

    public virtual void AddItem()
    {
        
    }

    public virtual void RemoveItem()
    {
        
    }

    public virtual void Select(GameObject item)
    {
        DeselectList();
        selectedItem = item;
    }

    public virtual void Deselect()
    {
        selectedItem = null;
    }

    public void DeselectList()
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            CollapsableMenu menu =  menuItems[i].GetComponent<CollapsableMenu>();
            if (menu.isSelected)
            {
                menu.Deselect();
                selectedItem = null;
            }
        }
    }
}
