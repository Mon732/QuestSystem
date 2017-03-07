using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager
{
    static QuestManager _instance;
    List<Quest> quests;

    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new QuestManager();
            }

            return _instance;
        }
    }

    private QuestManager()
    {
        quests = new List<Quest>();

        for (int k = 0; k < 20; k++)
        {
            quests.Add(new Quest("test" + k, "A Test of Quests: Part " + (k+1)));

            Quest.Stage[] stages = new Quest.Stage[5];

            for (int i = 0; i < stages.Length; i++)
            {
                stages[i] = new Quest.Stage(i);

                Quest.Stage.Objective[] objectives = new Quest.Stage.Objective[2];

                for (int j = 0; j < objectives.Length; j++)
                {
                    objectives[j] = new Quest.Stage.Objective("Do a thing");
                }

                stages[i].DefineObjectives(objectives);
            }

            quests[k].DefineStages(stages);
        }
    }

    public Quest GetQuest(string id)
    {
        foreach (Quest quest in quests)
        {
            if (quest.GetID() == id)
            {
                return quest;
            }
        }

        return null;
    }

    public Quest GetQuest(int index)
    {
        return quests[index];
    }

    public Quest AddQuest(string id, string name)
    {
        Quest quest = new Quest("test", "A Test of Quests: Part ");

        Quest.Stage[] stages = new Quest.Stage[1];
        stages[0] = new Quest.Stage(0);

        Quest.Stage.Objective[] objectives = new Quest.Stage.Objective[1];
        objectives[0] = new Quest.Stage.Objective("Do a thing");

        stages[0].DefineObjectives(objectives);
        quest.DefineStages(stages);

        quests.Add(quest);
        return quest;
    }

    public void EmptyFunction()
    {

    }
}
