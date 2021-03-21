using UnityEngine;

namespace Movement
{
    public abstract class MyInput : MonoBehaviour
    {
        public Vector3 MoveDirection { get; set; }
        public float Speed { get; set; }


    }
}
