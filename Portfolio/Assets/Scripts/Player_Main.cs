using UnityEngine;

namespace Player
{
    public class Player_Main : MonoBehaviour
    {
        public GameObject soldier;
        public Player_Team team;

        // Use this for initialization
        void Start()
        {
            GameObject newSoldier = Instantiate<GameObject>(soldier, this.gameObject.transform);
            team.AddTeamMember(newSoldier.GetComponent<PlayerCharacter_Soldier>());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print(team.TeamMembers.Count);
            }
        }
    }
}
