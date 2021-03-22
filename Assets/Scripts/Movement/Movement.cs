using System.Globalization;
using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] 
        private float speed;
    
        private MyInput _input;
        private Rigidbody2D _rb;
        void Start()
        {
            _input = GetComponent<MyInput>();
            _rb = GetComponent<Rigidbody2D>();
            speed = _input.Speed;
        }

        void FixedUpdate()
        {
            var input = _input.MoveDirection;
            _rb.velocity = (Vector2) input *  speed + new Vector2(0, _rb.velocity.y);
        }
    }
}


