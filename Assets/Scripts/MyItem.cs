using System;
using UnityEngine;

public class MyItem : Interactable
{
    public StatModifier Mod1 = new StatModifier(5);

    private const bool InDebug = true;

    private void Update()
    {
        if (Vector3.Distance(CharacterStats.Instance.transform.position, transform.position) < 0.5f)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                print("MyItem was equipped!");
                Equip(CharacterStats.Instance);
            }
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            print("MyItem was unequipped!");
            Unequip(CharacterStats.Instance);
        }
    }

    public void Equip(CharacterStats characterStats)
    {
        characterStats.jumpHeight.AddModifier(Mod1);
    }

    public void Unequip(CharacterStats characterStats)
    {
        characterStats.jumpHeight.RemoveModifier(Mod1);
    }
}