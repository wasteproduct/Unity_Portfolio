using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class Tutorial_SoundTest : MonoBehaviour
    {
        public AudioClip gunShot;
        public int shotCount;
        public float interval;

        public void Play()
        {
            AudioSource.PlayClipAtPoint(gunShot, new Vector3(0, 0, -10));
        }

        private IEnumerator PlaySound()
        {
            yield return new WaitForSeconds(1.0f);

            float elapsedTime = 0.0f;
            int count = 0;

            while (true)
            {
                elapsedTime += Time.deltaTime;

                if (elapsedTime >= interval)
                {
                    AudioSource.PlayClipAtPoint(gunShot, Camera.main.transform.position);
                    elapsedTime = 0.0f;
                    count++;
                }

                if (count >= shotCount) break;

                yield return null;
            }
        }

        // Use this for initialization
        void Start()
        {
            StartCoroutine(PlaySound());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
