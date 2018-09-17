using UnityEngine;

namespace MapObject
{
    public class Object_Door : MonoBehaviour
    {
        public int X { get; private set; }
        public int Z { get; private set; }
        public bool Highlighted { get; private set; }

        private Object_DoorHighlighter doorHighlighter;

        // Use this for initialization
        void Start()
        {
            doorHighlighter = this.GetComponentInChildren<Object_DoorHighlighter>();

            Highlighted = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ResetDoorColor()
        {
            doorHighlighter.ResetColor();

            Highlighted = false;
        }

        public void HighlightDoor()
        {
            doorHighlighter.HighlightDoor();

            Highlighted = true;
        }

        public void SetIndex(int x, int z)
        {
            X = x;
            Z = z;
        }

        public void Open()
        {
            GetComponent<Animator>().SetTrigger("DoorATrigger");
        }
    }
}
