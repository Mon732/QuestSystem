using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest
{
    public string id;
    public string name;
    public int currentStage;
    public Stage[] stages;

    public Quest()
    {

    }

    public Quest(string idString, string questName = "")
    {
        id = idString;
        name = questName;
    }
    
    public string GetID()
    {
        return id;
    }

    public void SetID(string newId)
    {
        id = newId;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public int GetCurrentStage()
    {
        return currentStage;
    }

    public Stage GetStage()
    {
        return stages.First(s => s.GetIndex() == currentStage);
    }

    public Stage GetStage(int stageNumber)
    {
        return stages.First(s => s.GetIndex() == stageNumber);
    }

    public Stage[] GetStages()
    {
        return stages;
    }

    public void SetStage(int stageNumber)
    {
        Stage stage = stages.First(s => s.GetIndex() == stageNumber);
        currentStage = stage.GetIndex();
    }

    public void DefineStages(Stage[] newStages)
    {
        stages = newStages.OrderBy(s => s.GetIndex()).ToArray();
    }
}
