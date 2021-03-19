using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MyInput
{
    void Update()
    {
        MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }

}