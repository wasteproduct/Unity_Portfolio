using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Sound", order = 1)]
public class CustomSound : ScriptableObject
{
    [SerializeField]
    private AudioClip playedSound;
    [SerializeField]
    private int repetitionCount;
    [SerializeField]
    private float startPlayingTime;
    [SerializeField]
    private float repetitionInterval;

    public AudioClip PlayedSound { get { return playedSound; } }
    public int RepetitionCount { get { return repetitionCount; } }
    public float StartPlayingTime { get { return startPlayingTime; } }
    public float RepetitionInterval { get { return repetitionInterval; } }
}
