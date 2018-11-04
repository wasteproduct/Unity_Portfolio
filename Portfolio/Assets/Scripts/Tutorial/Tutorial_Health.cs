using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class Tutorial_Health : MonoBehaviour
    {
        public Slider healthBar;
        public float maximumHealth;
        public Text healthText;

        private float currentHealth;

        // Use this for initialization
        void Start()
        {
            healthBar.maxValue = maximumHealth;
            healthBar.minValue = 0.0f;

            currentHealth = maximumHealth;
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.value = currentHealth;
            healthText.text = currentHealth.ToString() + " / " + maximumHealth.ToString();

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentHealth -= 10.0f;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentHealth += 5.0f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Rotate(0.0f, -4.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Rotate(0.0f, 4.0f, 0.0f);
            }
        }
    }
}
