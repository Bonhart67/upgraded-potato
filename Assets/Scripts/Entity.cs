using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private float hp = 100;

    public float Hp { get; set; }


    private void Update()
    {
        if (hp <= 0)
        {
            //DeathAnimation
            //TriggerGameOver
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D projectile)
    {
        hp -= projectile.gameObject.GetComponent<Attack>().damage;
    }
}