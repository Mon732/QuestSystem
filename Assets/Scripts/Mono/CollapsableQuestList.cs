using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsableQuestList : CollapsableList
{
    public CollapsableStageList stageList;

    public override void GenerateList()
    {
        base.GenerateList();

        Debug.Log("CollapsableQuestList");

        for (int i = 0; i < 20; i++)
        {
            GameObject item = Instantiate(menuItem, transform, false);
            CollapsableQuestMenu menu = item.GetComponent<CollapsableQuestMenu>();

            item.transform.SetAsLastSibling();
            menu.list = this;
            menuItems.Add(item);
            menu.SetQuestID(QuestManager.Instance.GetQuest(i).GetID());
        }

        AlignList();
    }

    public override void AddItem()
    {
        base.AddItem();

        Quest quest = QuestManager.Instance.AddQuest("NewQ", "New Quest");

        GameObject item = Instantiate(menuItem, transform, false);
        CollapsableQuestMenu menu = item.GetComponent<CollapsableQuestMenu>();

        item.transform.SetAsLastSibling();
        menu.list = this;
        menuItems.Add(item);
        menu.SetQuestID(quest.GetID());

        AlignList();
    }

    public override void RemoveItem()
    {
        base.RemoveItem();

        if (selectedItem != null)
        {
            string id = selectedItem.GetComponent<CollapsableQuestMenu>().GetQuestID();
            QuestManager.Instance.RemoveQuest(id);

            menuItems.Remove(selectedItem);
            Destroy(selectedItem);
            Deselect();

            AlignList();
        }
    }

    public override void Select(GameObject item)
    {
        base.Select(item);

        stageList.SetQuestId(selectedItem.GetComponent<CollapsableQuestMenu>().GetQuestID());
        stageList.GenerateList();
    }

    public override void Deselect()
    {
        base.Deselect();

        //stageList.selectedItem.GetComponent<CollapsableStageMenu>().Deselect();
        stageList.Deselect();
        stageList.SetQuestId("");
        stageList.GenerateList();
    }
}
