using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    private MyInput _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<MyInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var input = _input.MoveDirection;
        transform.position += input * (Time.deltaTime * _speed);
    }
}


