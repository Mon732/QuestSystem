using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsableObjectiveList : CollapsableList
{
    public CollapsableStageList stageList;

    int stageIndex = -1;

    protected override void Start()
    {
        base.Start();

        
    }

    public void SetStageIndex(int id)
    {
        stageIndex = id;
    }

    public int GetStageIndex()
    {
        return stageIndex;
    }

    public Objective GetObjective(int objectiveIndex)
    {
        string questID = stageList.GetQuestId();
        Quest quest = QuestManager.Instance.GetQuest(questID);
        Stage stage = quest.GetStage(stageIndex);
        Objective[] objectives = stage.GetObjectives();

        return objectives[objectiveIndex];
    }

    public override void GenerateList()
    {
        base.GenerateList();

        Debug.Log("CollapsableObjectiveList");

        if (stageIndex < 0)
        {
            //Debug.LogWarning("Objective List stage index is empty");
            return;
        }

        string questID = stageList.GetQuestId();
        Quest quest = QuestManager.Instance.GetQuest(questID);
        Stage stage = quest.GetStage(stageIndex);
        Objective[] objectives = stage.GetObjectives();

        for (int i = 0; i < objectives.Length; i++)
        {
            GameObject item = Instantiate(menuItem, transform, false);
            CollapsableObjectiveMenu menu = item.GetComponent<CollapsableObjectiveMenu>();

            item.transform.SetAsLastSibling();
            menu.list = this;
            menuItems.Add(item);
            menu.SetObjectiveIndex(i);

            AlignList();
        }
    }

    public override void AddItem()
    {
        base.AddItem();

        //List<Stage> stages = QuestManager.Instance.GetQuest(stageIndex).GetStages().ToList<Stage>();
        //Stage newStage = new Stage(500);
        //stages.Add(newStage);
        //QuestManager.Instance.GetQuest(stageIndex).DefineStages(stages.ToArray());

        GameObject item = Instantiate(menuItem, transform, false);
        CollapsableObjectiveMenu menu = item.GetComponent<CollapsableObjectiveMenu>();

        item.transform.SetAsLastSibling();
        menu.list = this;
        menuItems.Add(item);
        menu.SetObjectiveIndex(69);

        AlignList();
    }

    public override void RemoveItem()
    {
        base.RemoveItem();

        if (selectedItem != null)
        {
            //int stageIndex = selectedItem.GetComponent<CollapsableStageMenu>().GetStageIndex();
            //List<Stage> stages = QuestManager.Instance.GetQuest(this.stageIndex).GetStages().ToList<Stage>();
            //Stage stage = QuestManager.Instance.GetQuest(this.stageIndex).GetStage(stageIndex);
            //stages.Remove(stage);

            //QuestManager.Instance.GetQuest(this.stageIndex).DefineStages(stages.ToArray());

            menuItems.Remove(selectedItem);
            Destroy(selectedItem);
            Deselect();

            AlignList();
        }
    }
}
