using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollapsableStageList : CollapsableList
{
    public CollapsableQuestList questList;
    public CollapsableObjectiveList objectiveList;

    string questId;

    protected override void Start()
    {
        base.Start();
    }

    public void SetQuestId(string id)
    {
        questId = id;
    }

    public string GetQuestId()
    {
        return questId;
    }

    public override void GenerateList()
    {
        base.GenerateList();

        Debug.Log("CollapsableStageList");

        if (questId == "" || questId == null)
        {
            //Debug.LogWarning("Stage List quest ID is empty");
            return;
        }

        Quest quest = QuestManager.Instance.GetQuest(questId);
        Stage[] stages = quest.GetStages();

        for (int i = 0; i < stages.Length; i++)
        {
            GameObject item = Instantiate(menuItem, transform, false);
            CollapsableStageMenu menu = item.GetComponent<CollapsableStageMenu>();

            item.transform.SetAsLastSibling();
            menu.list = this;
            menuItems.Add(item);
            menu.SetStageIndex(stages[i].GetIndex());

            AlignList();
        }
    }

    public override void AddItem()
    {
        base.AddItem();

        List<Stage> stages = QuestManager.Instance.GetQuest(questId).GetStages().ToList<Stage>();
        Stage newStage = new Stage(500);
        stages.Add(newStage);
        QuestManager.Instance.GetQuest(questId).DefineStages(stages.ToArray());

        GameObject item = Instantiate(menuItem, transform, false);
        CollapsableStageMenu menu = item.GetComponent<CollapsableStageMenu>();

        item.transform.SetAsLastSibling();
        menu.list = this;
        menuItems.Add(item);
        menu.SetStageIndex(newStage.GetIndex());

        AlignList();
    }

    public override void RemoveItem()
    {
        base.RemoveItem();

        if (selectedItem != null)
        {
            int stageIndex = selectedItem.GetComponent<CollapsableStageMenu>().GetStageIndex();
            List<Stage> stages = QuestManager.Instance.GetQuest(questId).GetStages().ToList<Stage>();
            Stage stage = QuestManager.Instance.GetQuest(questId).GetStage(stageIndex);
            stages.Remove(stage);

            QuestManager.Instance.GetQuest(questId).DefineStages(stages.ToArray());

            menuItems.Remove(selectedItem);
            Destroy(selectedItem);
            Deselect();

            AlignList();
        }
    }

    public override void Select(GameObject item)
    {
        base.Select(item);

        objectiveList.SetStageIndex(selectedItem.GetComponent<CollapsableStageMenu>().GetStageIndex());
        objectiveList.GenerateList();
    }

    public override void Deselect()
    {
        base.Deselect();

        objectiveList.Deselect();
        objectiveList.SetStageIndex(-1);
        objectiveList.GenerateList();
    }
}
