using System.Collections.Generic;

public class Item
{
    public List<Stat> Stats { get; set; }
    public string ObjectSlug { get; set; }

    public Item(List<Stat> stats, string objectSlug)
    {
        Stats = stats;
        ObjectSlug = objectSlug;
    }
}
