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


    // Use this for initialization
    void Start()
    {
        properties.SetActive(false);
        isOpen = false;
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
        list.Select(this.gameObject);
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

    public virtual void GetProperties()
    {
        
    }

    public virtual void SetProperties()
    {
        
    }
}
