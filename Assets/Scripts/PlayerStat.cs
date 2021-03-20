using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    
    public BaseStat _power = new BaseStat(4, "power");
    public BaseStat _intelligence = new BaseStat(3, "intelligence");
    public BaseStat _dexterity = new BaseStat(5, "dexterity");

    private List<BaseStat> BonusStatList = new List<BaseStat>();
    
    private static PlayerStat _instance;
    public static PlayerStat Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void AddBonusStat(BaseStat bonusStat)
    {
        BonusStatList.Add(bonusStat);
        
        /*switch (bonusStat.statName)
        {
           case "power" :
               _power.statValue += bonusStat.statValue;
                break;
           case "intelligence" :
               _intelligence.statValue += bonusStat.statValue;
               break;
           case "dexterity" :
               _dexterity.statValue += bonusStat.statValue;
               break;
        }*/
    }

    void GetStat(string statName)
    {
        int baseStat = statName switch
        {
            "power" => _power.statValue,
            "intelligence" => _intelligence.statValue,
            "dexterity" => _dexterity.statValue,
            _ => 0
        };

        var bonusStat = BonusStatList.Where(x => x.statName == statName).Select(x => x.statValue).Sum();
        print(baseStat+bonusStat);
        //return baseStat + bonusStat;
    }

    private void Start()
    {
        GetStat("power");
        AddBonusStat(new BaseStat(3, "power"));
        GetStat("power");
    }
}
