using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest
{
    string id;
    string name;
    int currentStage;
    Stage[] stages;

    public class Stage
    {
        public int index;
        Objective[] objectives;

        public class Objective
        {
            public string text;
            public bool completed;

            public Objective(string displayText)
            {
                text = displayText;
                completed = false;
            }
        }

        public Stage(int stageNumber)
        {
            index = stageNumber;
        }
        
        public void DefineObjectives(Objective[] newObjectives)
        {
            objectives = newObjectives;
        }

        public void SetObjective(int objectiveIndex, bool completed)
        {
            objectives[objectiveIndex].completed = completed;
        }
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

    public int GetStage()
    {
        return currentStage;
    }

    public void SetStage(int stageNumber)
    {
        Stage stage = stages.First(s => s.index == stageNumber);
        currentStage = stage.index;
    }

    public void DefineStages(Stage[] newStages)
    {
        stages = newStages;
    }
}
