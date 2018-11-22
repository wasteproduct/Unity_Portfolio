using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public Event_SoundPlay eventSoundPlay;

    public void PlaySound()
    {
        if (eventSoundPlay.PlayedSound == null) return;
    }

    //private IEnumerator SoundPlay()
    //{
    //    CustomSound playedSound = eventSoundPlay.PlayedSound;

    //    yield return new WaitForSeconds(playedSound.StartPlayingTime);

    //    int playCount = 1;
    //    float elapsedTime = 0.0f;

    //    while(true)
    //    {
            
    //    }
    //}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
