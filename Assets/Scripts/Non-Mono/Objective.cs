using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective
{
    public string description;
    public bool completed;

    public Objective()
    {

    }

    public Objective(string displayText)
    {
        description = displayText;
        completed = false;
    }
}
