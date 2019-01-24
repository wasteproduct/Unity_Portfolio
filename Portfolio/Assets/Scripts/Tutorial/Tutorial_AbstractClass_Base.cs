using UnityEngine;

namespace Tutorial
{
    public abstract class Tutorial_AbstractClass_Base : MonoBehaviour
    {
        [SerializeField]
        protected int value;

        public int Value { get { return value; } }

        public void IncreaseValue() { value++; }
    }
}
