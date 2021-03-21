using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Stat
{
    public float BaseValue;

    private bool IsDirty = true;
    private float _value;

    public float Value
    {
        get
        {
            if (IsDirty)
            {
                IsDirty = false;
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
    
    public Stat(int baseValue) : this()
    {
        BaseValue = baseValue;

    }

    public void AddModifier(StatModifier mod)
    {
        _statModifiers.Add(mod);
        IsDirty = true;
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (_statModifiers.Remove(mod))
        {
            IsDirty=true;
            return true;
        }

        return false;
    }

    private float CalculateFinaleValue()
    {
        float finaleValue = BaseValue;

        for (int i = 0; i < _statModifiers.Count; i++)
        {
            finaleValue += _statModifiers[i].Value;
        }

        return (float) Math.Round(finaleValue, 4);
    }
}