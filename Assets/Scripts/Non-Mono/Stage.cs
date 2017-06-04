using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public int index;
    public Objective[] objectives;

    public Stage()
    {

    }

    public Stage(int stageNumber)
    {
        index = stageNumber;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(int newIndex)
    {
        index = newIndex;
    }

    public void DefineObjectives(Objective[] newObjectives)
    {
        objectives = newObjectives;
    }

    public Objective[] GetObjectives()
    {
        return objectives;
    }

    public void SetObjective(int objectiveIndex, bool completed)
    {
        objectives[objectiveIndex].completed = completed;
    }
}
