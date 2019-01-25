using UnityEngine;

public abstract class Quest_Base : ScriptableObject
{
    [SerializeField]
    protected TextAsset questText;
    [SerializeField]
    protected TextAsset objective;
    [SerializeField]
    protected int toComplete;

    public string QuestText { get { return questText.text; } }
    public string Objective { get { return objective.text; } }
    public string QuestName { get { return questText.name; } }
    public bool QuestGiven { get; protected set; }
    public int Progress { get; protected set; }
    public bool ProgressionComplete { get; protected set; }
    public bool QuestComplete { get; protected set; }

    public void UpdateProgression()
    {
        if (ProgressionComplete == true) return;

        Progress++;

        if (Progress >= toComplete)
        {
            ProgressionComplete = true;
            ProgressionCompleted();
        }
    }

    public void Given(bool flag)
    {
        QuestGiven = flag;
        Progress = 0;

        ProgressionComplete = false;

        QuestComplete = false;
    }

    public abstract void ProgressionCompleted();
}
