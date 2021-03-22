using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //This will need to go
    public Stat jumpHeight = new Stat(5, "jumpHeight");

    public List<Stat> Stats = new List<Stat>();

    private void Start()
    {
        Stats.Add(new Stat(3, "Power"));
    }

    public void AddStatBonus(List<Stat> statBonuses)
    {
        foreach (Stat statBonus in statBonuses)
        {
            Stats.Find(x => x.StatName == statBonus.StatName).AddModifier(new StatModifier(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<Stat> statBonuses)
    {
        foreach (Stat statBonus in statBonuses)
        {
            Stats.Find(x => x.StatName == statBonus.StatName).RemoveModifier(new StatModifier(statBonus.BaseValue));
        }
    }
    
    #region Singleton

    public static CharacterStats Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    
    
    //For Debugging
    /*private float temp = 5;
    private void Update()
    {
        if (jumpHeight.Value != temp)
        {
            print($"temp: {temp} while jumpHeight: {jumpHeight.Value}");
            temp = jumpHeight.Value;
        }
    }*/
}
