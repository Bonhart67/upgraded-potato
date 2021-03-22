using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;
    public Item sword;

    private void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<Stat> swordStats = new List<Stat> {new Stat(6, "Power")};
        sword = new Item(swordStats, "sword");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerWeaponController.PerformWeaponAttack();
        }
    }
}