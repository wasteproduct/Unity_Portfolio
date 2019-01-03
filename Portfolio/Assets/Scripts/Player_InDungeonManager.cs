using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player_InDungeonManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject portraitsPanel;
        [SerializeField]
        private GameObject portraitPrefab;
        [SerializeField]
        private GameObject noticingWindow;

        public void GetNewItem()
        {
            noticingWindow.gameObject.SetActive(true);
            noticingWindow.GetComponent<UI_NoticingWindow>().ShowNewItem();
        }

        public void Initialize()
        {
            List<GameObject> playerCharacters = GetComponent<Player_DungeonSettings>().PlayerCharacters;

            for (int i = 0; i < playerCharacters.Count; i++)
            {
                GameObject newPortrait = Instantiate(portraitPrefab, portraitsPanel.transform);
                newPortrait.GetComponent<Character_InDungeonPortrait>().Initialize(playerCharacters[i]);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
