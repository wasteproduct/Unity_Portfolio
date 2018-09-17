using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Player/Team", order = 1)]
public class Player_Team : ScriptableObject
{
    private List<Player_Character> teamMembers = new List<Player_Character>();
    public List<Player_Character> TeamMembers { get { return teamMembers; } }

    public void AddTeamMember(Player_Character newMember) { if (teamMembers.Contains(newMember) == false) teamMembers.Add(newMember); }
    public void RemoveTeamMember(Player_Character removedMember) { if (teamMembers.Contains(removedMember) == true) teamMembers.Remove(removedMember); }

    private void OnDisable()
    {
        for (int i = teamMembers.Count - 1; i >= 0; i--)
        {
            teamMembers.RemoveAt(i);
        }

        teamMembers.Clear();
    }
}
