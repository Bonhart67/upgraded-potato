using System;
using System.Globalization;
using UnityEngine;

namespace Movement
{
    public class PlayerInput : MyInput
    {
        private void Awake()
        {
            Speed = 15f;
        }

        void Update()
        {
            MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        

    }
}