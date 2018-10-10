using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "", menuName = "Player/Move Controller", order = 1)]
    public class Player_MoveController : ScriptableObject
    {
        public bool moving;
        public float elapsedTime;

        private readonly float elapsedTimeLimit = .2f;

        public float ElapsedTimeLimit { get { return elapsedTimeLimit; } }

        public void Initialize()
        {
            moving = false;
            elapsedTime = 0.0f;
        }

        Vector3 LerpPosition(Vector3 startPosition, Vector3 endPosition)
        {
            return Vector3.zero;
        }
    }
}
