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
    public bool QuestGiven { get; private set; }
    public int Progress { get; private set; }
    public bool ProgressionComplete { get { return Progress >= toComplete; } }

    public void UpdateProgression() { Progress++; }

    public void Given(bool flag)
    {
        QuestGiven = flag;
        Progress = 0;
    }
}
