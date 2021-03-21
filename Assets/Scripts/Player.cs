using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public Stat jumpHeight = new Stat(5);
    

    
    #region Singleton
    private static Player _instance;

    public static Player Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private float temp = 5;
    private void Update()
    {
        if (jumpHeight.Value != temp)
        {
            print($"temp: {temp} while jumpHeight: {jumpHeight.Value}");
            temp = jumpHeight.Value;
        }
    }
}
