using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar_Revealer : MonoBehaviour
{
    [SerializeField]
    private int revealedDistance;

    public int RevealedDistance { get { return revealedDistance; } }

    public void RegisterRevealer()
    {
        FogOfWar_Manager.Instance.RegisterRevealer(this);
    }
}
