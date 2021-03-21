using System;
using UnityEngine;

public class Item : Interactable
{
    public StatModifier Mod1 = new StatModifier(5);

    private const bool InDebug = true;

    private void Update()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) < 0.5f)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                print("Item was equipped!");
                Equip(Player.Instance);
            }
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            print("Item was unequipped!");
            Unequip(Player.Instance);
        }
    }

    public void Equip(Player player)
    {
        player.jumpHeight.AddModifier(Mod1);
    }

    public void Unequip(Player player)
    {
        player.jumpHeight.RemoveModifier(Mod1);
    }
}