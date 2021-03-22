using System.Collections.Generic;

public interface IWeapon
{
    public List<Stat> Stats { get; set; }
    void PerformAttack();

}
