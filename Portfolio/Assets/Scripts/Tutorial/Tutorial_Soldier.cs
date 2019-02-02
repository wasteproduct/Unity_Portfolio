using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_Soldier : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private float movingSpeed;

        public delegate void Delegate_Void();

        public bool Moving { get { return animator.GetBool("Moving"); } }

        public IEnumerator Move(List<Node_AStar> finalTrack, Delegate_Void ClearTraceMark)
        {
            animator.SetBool("Moving", true);

            for (int i = 1; i < finalTrack.Count; i++)
            {
                Node_AStar startNode = finalTrack[i - 1];
                Node_AStar endNode = finalTrack[i];

                float startingRotation = transform.rotation.eulerAngles.y;
                float targetRotation = CalculateTargetRotation(startNode, endNode);

                if (targetRotation > startingRotation && targetRotation - startingRotation > 180.0f) startingRotation += 360.0f;
                if (targetRotation < startingRotation && startingRotation - targetRotation > 180.0f) targetRotation += 360.0f;

                float elapsedTime = 0.0f;

                while (true)
                {
                    if (elapsedTime >= (1 / movingSpeed)) break;

                    elapsedTime += Time.deltaTime;

                    float x = Mathf.Lerp(startNode.X, endNode.X, elapsedTime / (1 / movingSpeed));
                    float z = Mathf.Lerp(startNode.Z, endNode.Z, elapsedTime / (1 / movingSpeed));

                    float rotation = Mathf.Lerp(startingRotation, targetRotation, elapsedTime / (1 / movingSpeed));

                    transform.position = new Vector3(x, 0, z);
                    transform.rotation = Quaternion.Euler(0, rotation, 0);

                    yield return null;
                }
            }

            animator.SetBool("Moving", false);

            ClearTraceMark();
        }

        private float CalculateTargetRotation(Node_AStar startNode, Node_AStar endNode)
        {
            int horizontal = endNode.X - startNode.X;
            int vertical = endNode.Z - startNode.Z;

            if (vertical < 0)
            {
                if (horizontal > 0) return 135.0f;
                else if (horizontal == 0) return 180.0f;
                else return 225.0f;
            }
            else if (vertical == 0)
            {
                if (horizontal > 0) return 90.0f;
                else return 270.0f;
            }
            else
            {
                if (horizontal < 0) return 315.0f;
                else if (horizontal == 0) return 0.0f;
                else return 45.0f;
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
