using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CollapsableObjectiveMenu : CollapsableMenu
{
    int objectiveIndex;

    public void SetObjectiveIndex(int newIndex)
    {
        objectiveIndex = newIndex;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ((CollapsableObjectiveList)list).GetObjective(objectiveIndex).description;
    }

    public int GetObjectiveIndex()
    {
        return objectiveIndex;
    }

    public override void GetProperties()
    {
        base.GetProperties();

        Objective objective = ((CollapsableObjectiveList)list).GetObjective(objectiveIndex);

        properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = objective.description;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = objective.description;
    }

    public override void SetProperties()
    {
        base.SetProperties();

        string newDescription = properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text;

        string questId = ((CollapsableObjectiveList)list).stageList.GetQuestId();
        int stageIndex = ((CollapsableObjectiveList)list).GetStageIndex();

        Stage[] stages = QuestManager.Instance.GetQuest(questId).GetStages();
        Stage stage = stages.First(s => s.GetIndex() == (stageIndex));
        Objective[] objectives = stage.GetObjectives();

        int stagePos = System.Array.IndexOf(stages, stage);

        objectives[objectiveIndex].description = newDescription;
        objectives[objectiveIndex].completed = false;

        stage.DefineObjectives(objectives);
        stages[stagePos] = stage;
        QuestManager.Instance.GetQuest(questId).DefineStages(stages);

        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = newDescription;
    }
}
