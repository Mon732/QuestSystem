using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CollapsableStageMenu : CollapsableMenu
{
    int stageIndex;

    public void SetStageIndex(int newIndex)
    {
        stageIndex = newIndex;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Stage " + stageIndex;
    }

    public int GetStageIndex()
    {
        return stageIndex;
    }

    public override void GetProperties()
    {
        base.GetProperties();

        properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = stageIndex.ToString();
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Stage " + stageIndex.ToString();
    }

    public override void SetProperties()
    {
        base.SetProperties();

        int newIndex = int.Parse(properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text);

        string questId = ((CollapsableStageList)list).GetQuestId();
        Stage[] stages = QuestManager.Instance.GetQuest(questId).GetStages();

        if (stages.FirstOrDefault(s => s.GetIndex() == newIndex) == null)
        {
            Stage stage = stages.First(s => s.GetIndex() == stageIndex);
            int stagePos = System.Array.IndexOf(stages, stage);

            SetStageIndex(newIndex);

            stage.SetIndex(stageIndex);
            stages[stagePos] = stage;
            QuestManager.Instance.GetQuest(questId).DefineStages(stages);

            list.GenerateList();
        }
        else
        {
            properties.transform.GetChild(0).transform.GetChild(0).GetComponent<InputField>().text = stageIndex.ToString();
        }
    }
}
