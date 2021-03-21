using System.Globalization;
using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] 
        private float speed;
    
        private MyInput _input;
        void Start()
        {
            _input = GetComponent<MyInput>();
            speed = _input.Speed;
        }

        void FixedUpdate()
        {
            var input = _input.MoveDirection;
            transform.position += input * (Time.deltaTime * speed);
        }
    }
}


