using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect
{
    public string EffectName { get; protected set; }

    public ItemEffect(string effectName)
    {
        EffectName = effectName;
    }

    public virtual void ApplyEffect(BieberLogic bieber)
    {
        // Check the effect name and apply the corresponding effect
        if (EffectName == "Double Speed")
        {
            // Double the Bieber's movement speed
            bieber.DoubleSpeed();
        }
        else if (EffectName == "Heal")
        {
            // Increase the Bieber's health by 1
            bieber.Heal();
        }
        else
        {
            Debug.LogWarning("Unsupported effect: " + EffectName);
        }
    }
}

public class DoubleSpeedEffect : ItemEffect
{
    public DoubleSpeedEffect() : base("Double Speed")
    {
    }

    public override void ApplyEffect(BieberLogic bieber)
    {
        bieber.DoubleSpeed();
    }
}

public class HealEffect : ItemEffect
{
    public HealEffect() : base("Heal")
    {
    }

    public override void ApplyEffect(BieberLogic bieber)
    {
        bieber.Heal();
    }
}