using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public Event_SoundPlay eventSoundPlay;

    public void PlaySound()
    {
        StartCoroutine(SoundPlay());
    }

    private IEnumerator SoundPlay()
    {
        CustomSound playedSound = eventSoundPlay.PlayedSound;

        yield return new WaitForSeconds(playedSound.StartPlayingTime);

        int playCount = 0;

        while (true)
        {
            AudioSource.PlayClipAtPoint(playedSound.PlayedSound, Camera.main.transform.position);
            playCount++;

            if (playCount >= playedSound.RepetitionCount) break;

            yield return new WaitForSeconds(playedSound.RepetitionInterval);
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
