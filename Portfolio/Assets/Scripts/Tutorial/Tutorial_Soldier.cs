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

        private float speed;

        public bool Moving { get { return animator.GetBool("Moving"); } }

        public IEnumerator Move(List<Node_AStar> finalTrack)
        {
            animator.SetBool("Moving", true);

            for (int i = 1; i < finalTrack.Count; i++)
            {
                Node_AStar startNode = finalTrack[i - 1];
                Node_AStar endNode = finalTrack[i];

                float elapsedTime = 0.0f;

                while (true)
                {
                    if (elapsedTime >= speed) break;

                    elapsedTime += Time.deltaTime;

                    float x = Mathf.Lerp(startNode.X, endNode.X, elapsedTime / speed);
                    float z = Mathf.Lerp(startNode.Z, endNode.Z, elapsedTime / speed);

                    transform.position = new Vector3(x, 0, z);

                    yield return null;
                }
            }

            animator.SetBool("Moving", false);
        }

        // Use this for initialization
        void Start()
        {
            speed = 1 / movingSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print(transform.forward);
            }
        }
    }
}
