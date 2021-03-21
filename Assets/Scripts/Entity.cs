using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour
{
    private float _hp = 100;
    public float Hp => _hp;

    private void Update()
    {
        if (_hp <= 0)
        {
            //DeathAnimation
            //TriggerGameOver
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D projectile)
    {
        
        
        if (projectile.GetComponent<Attack>() != null)
        {
            _hp -= projectile.gameObject.GetComponent<Attack>().damage;
            /*PlayerStat.Instance._power.statValue--;
            print(PlayerStat.Instance._power.statValue);*/
        }
    }
}