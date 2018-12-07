using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar_Revealer : MonoBehaviour
{
    [SerializeField]
    private int revealedAreaRadius;

    public int RevealedAreaRadius { get { return revealedAreaRadius; } }

    public void SetRadius(int newRadius)
    {
        revealedAreaRadius = newRadius;
    }

    public void RegisterRevealer()
    {
        FogOfWar_Manager.Instance.RegisterRevealer(this);
    }
}
