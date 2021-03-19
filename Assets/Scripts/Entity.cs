using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private float hp = 10;

    public float Hp => hp;


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