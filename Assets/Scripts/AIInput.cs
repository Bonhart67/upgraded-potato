using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MyInput
{
    private float _direction = 1f;
    
    void Update()
    {

        switch (_direction)
        {
            case 1f:
                if (transform.position.x >= 10)
                {
                    _direction = -1f;
                }
                break;
            case -1f:
                if (transform.position.x <= 0 )
                {
                    _direction = 1f;
                }
                break;
        }
        
        MoveDirection = new Vector3(_direction, 0, 0);

    }
}
