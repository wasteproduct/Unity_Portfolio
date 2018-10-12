using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;

public class Character_ExploreFellow : Character_Explore
{
    public Calculation_Move moveController;

    public override void Initialize(GameObject frontOne)
    {
        this.FrontOne = frontOne;

        this.PreviousPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);
    }

    public override void StartMoving(List<Node_AStar> entireTrack)
    {
        this.PreviousPosition = this.gameObject.transform.position;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float elapsedTime = 0.0f;

        while (true)
        {
            if (elapsedTime >= moveController.ElapsedTimeLimit)
            {
                if (moveController.moving == false) break;

                elapsedTime = 0.0f;
            }
            
            elapsedTime += Time.deltaTime;
            // 여기에 들어가는 position들이 너무 빈약하다
            //this.gameObject.transform.position = moveController.LerpPosition(this.PreviousPosition, this.FrontOne.GetComponent<Character_Explore>().PreviousPosition, elapsedTime);

            yield return null;
        }
        /*int targetIndex = 1;
        float elapsedTime = 0.0f;

        while (true)
        {
            if (elapsedTime >= moveController.ElapsedTimeLimit)
            {
                targetIndex++;
                elapsedTime = 0.0f;

                if (targetIndex >= aStar.FinalTrack.Count)
                {
                    if (doorTileClicked == true) clickEvent.doorTile.OpenDoor();

                    moveController.moving = false;
                    break;
                }
            }

            elapsedTime += Time.deltaTime;
            this.gameObject.transform.position = moveController.LerpPosition(aStar.FinalTrack[targetIndex - 1], aStar.FinalTrack[targetIndex], elapsedTime);

            yield return null;
        }*/
    }
}
