using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float amount;
    public DamageType type;
    public Transform source;

    public Damage(float a, DamageType t, Transform s)
    {
        amount = a;
        type = t;
        source = s;
    }
}
