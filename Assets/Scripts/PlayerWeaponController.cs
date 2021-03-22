using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    private GameObject EquippedWeaponObject { get; set; }

    private IWeapon _equippedWeapon;

    public void EquipWeapon(Item newWeapon)
    {
        RemoveOldWeaponIfThereIs();

        InstantiateNewWeapon(newWeapon);
        
        SetWeaponToNewWeapon();
        
        SetWeaponStatsToNewWeaponStats(newWeapon);
        
        PutWeaponInHand();
        
        RecalcNewStatsToCharacter(newWeapon);
        
        //print(equippedWeapon.Stats[0].Value);
    }

    #region EquipWeapon
    private void RemoveOldWeaponIfThereIs()
    {
        if (EquippedWeaponObject != null)
        {
            CharacterStats.Instance.RemoveStatBonus(_equippedWeapon.Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
    }

    private void SetWeaponToNewWeapon()
    {
        if(EquippedWeaponObject.GetComponent<IWeapon>() != null)
            _equippedWeapon = EquippedWeaponObject.GetComponent<IWeapon>();
    }

    private void InstantiateNewWeapon(Item itemToEquip)
    {
        EquippedWeaponObject = (GameObject) Instantiate(
            Resources.Load<GameObject>("Prefabs/Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);
    }

    private void SetWeaponStatsToNewWeaponStats(Item itemToEquip)
    {
        _equippedWeapon.Stats = itemToEquip.Stats;
    }

    private void PutWeaponInHand()
    {
        EquippedWeaponObject.transform.SetParent(playerHand.transform);
    }

    private void RecalcNewStatsToCharacter(Item itemToEquip)
    {
        CharacterStats.Instance.AddStatBonus(itemToEquip.Stats);
    }

    public void PerformWeaponAttack()
    {
        _equippedWeapon.PerformAttack();
    }
    

    #endregion
    
}