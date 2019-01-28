using UnityEngine;

public abstract class Quest_Base : ScriptableObject
{
    [SerializeField]
    protected TextAsset questText;
    [SerializeField]
    protected TextAsset objective;
    [SerializeField]
    protected Player.Player_Inventory inventory;

    public string QuestText { get { return questText.text; } }
    public string Objective { get { return objective.text; } }
    public string QuestName { get { return questText.name; } }
    public bool QuestGiven { get; protected set; }
    public int Progress { get; protected set; }
    public bool QuestComplete { get; protected set; }

    public void FinishQuest()
    {
        QuestComplete = true;

        FinishQuest_Abstract();
    }

    public void UpdateProgression(bool progressed = true)
    {
        if (progressed == false)
        {
            Progress--;

            if (Progress < 0) Progress = 0;

            return;
        }

        if (ProgressionComplete() == true) return;

        Progress++;

        if (ProgressionComplete() == true) ProgressionCompleted();
    }

    public void Given(bool flag)
    {
        QuestGiven = flag;
        Progress = 0;

        QuestComplete = false;
    }

    public abstract bool ProgressionComplete();

    protected abstract void ProgressionCompleted();
    protected abstract void FinishQuest_Abstract();
}
