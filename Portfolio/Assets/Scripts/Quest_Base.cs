using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "", order = 1)]
public class Quest_Base : ScriptableObject
{
    [SerializeField]
    private TextAsset questText;
    [SerializeField]
    private TextAsset objective;

    public string QuestText { get { return questText.text; } }
    public string Objective { get { return objective.text; } }
    public string QuestName { get { return questText.name; } }
    public bool QuestGiven { get; private set; }

    public void Given(bool flag) { QuestGiven = flag; }
}
