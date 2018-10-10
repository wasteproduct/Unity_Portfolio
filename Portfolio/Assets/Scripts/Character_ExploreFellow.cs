using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_ExploreFellow : Character_Explore
{
    public GameObject FrontOne { get; private set; }

    public void Initialize(GameObject frontOne)
    {
        FrontOne = frontOne;

        //elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void StartMoving()
    {
        //StartCoroutine(Move());
    }

    //private IEnumerator Move()
    //{
    //    Vector3 currentPosition = this.gameObject.transform.position;
    //    Vector3 nextPosition = FrontOne.gameObject.GetComponent<Character_InDungeon>().PreviousPosition;

    //    while (true)
    //    {
    //        if (elapsedTime >= elapsedTimeLimit)
    //        {
    //            elapsedTime = 0.0f;

    //            currentPosition = this.gameObject.transform.position;
    //            nextPosition = FrontOne.gameObject.GetComponent<Character_InDungeon>().PreviousPosition;

    //            this.gameObject.GetComponent<Character_InDungeon>().SetPreviousPosition(this.gameObject.transform.position);

    //            if (moving.flag == false) break;
    //        }

    //        elapsedTime += Time.deltaTime;
    //        float lerpTime = elapsedTime / elapsedTimeLimit;
    //        this.gameObject.transform.position = Vector3.Lerp(currentPosition, nextPosition, lerpTime);

    //        yield return null;
    //    }
    //}
}
