using UnityEngine;

namespace MapObject
{
    public class Object_DoorHighlighter : MonoBehaviour
    {
        private Color original;
        private Material material;

        // Use this for initialization
        void Start()
        {
            material = this.GetComponent<Renderer>().material;

            original = this.GetComponent<Renderer>().sharedMaterial.color;
        }

        public void HighlightDoor()
        {
            material.color = Color.green;
        }

        public void ResetColor()
        {
            material.color = original;
        }
    }
}
