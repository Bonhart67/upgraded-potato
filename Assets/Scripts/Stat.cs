using System;
using System.Collections.Generic;
using System.Linq;

public class Stat
{
    public float BaseValue;
    public string StatName;

    private bool _isDirty = true;
    private float _value;

    public float Value
    {
        get
        {
            if (_isDirty)
            {
                _isDirty = false;
                _value = CalculateFinaleValue();
            }
            return _value;
        }
    }

    private readonly List<StatModifier> _statModifiers;
    public readonly IReadOnlyCollection<StatModifier> StatModifiers;

    public Stat()
    {
        _statModifiers = new List<StatModifier>();
        StatModifiers = _statModifiers.AsReadOnly();
    }
    
    public Stat(int baseValue, string statName) : this()
    {
        BaseValue = baseValue;
        StatName = statName;
    }

    public void AddModifier(StatModifier mod)
    {
        _statModifiers.Add(mod);
        _isDirty = true;
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (_statModifiers.Remove(_statModifiers.Find(x => x.Value == mod.Value)))
        {
            _isDirty=true;
            return true;
        }

        return false;
    }

    private float CalculateFinaleValue()
    {
        float finaleValue = BaseValue + _statModifiers.Sum(t => t.Value);

        return (float) Math.Round(finaleValue, 4);
    }
}