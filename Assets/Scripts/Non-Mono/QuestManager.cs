using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
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

            Stage[] stages = new Stage[5];

            for (int i = 0; i < stages.Length; i++)
            {
                stages[i] = new Stage(i);

                Objective[] objectives = new Objective[2];

                for (int j = 0; j < objectives.Length; j++)
                {
                    objectives[j] = new Objective("Do a thing");
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
        Quest quest = new Quest(id, name);

        Stage[] stages = new Stage[1];
        stages[0] = new Stage(0);

        Objective[] objectives = new Objective[1];
        objectives[0] = new Objective("Do a thing");

        stages[0].DefineObjectives(objectives);
        quest.DefineStages(stages);

        quests.Add(quest);
        return quest;
    }

    public void RemoveQuest(string id)
    {
        Quest quest = GetQuest(id);
        quests.Remove(quest);
    }

    public bool Load(string filename)
    {
        

        return false;
    }

    public bool Save(string filename)
    {
        bool success = false;

        XmlSerializer serialiser = new XmlSerializer(typeof(List<Quest>));
        TextWriter writer = new StreamWriter(filename);

        try
        {
            serialiser.Serialize(writer, quests);

            success = true;
        }
        catch (System.Exception e)
        {

        }

        writer.Close();

        return success;
    }
}
