using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Movement;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    public GameObject monster;
    private Random rnd = new Random();

    private void Start()
    {
        Spawn();
    }

    private void OnMouseDown()
    {
        print("click");
        Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            print("key Spawn");
            Spawn();
        }
    }

    void Spawn()
    {
        MyInput instanc = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<MyInput>();
        instanc.Speed = rnd.Next(200, 600)/100f;
        print(instanc.Speed);
    }
}
