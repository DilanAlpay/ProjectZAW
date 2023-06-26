using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A power is an item you can use to do a super attack
/// </summary>
[CreateAssetMenu(menuName ="Power")]
public class Power : Weapon
{
    public Sprite icon;
    public int uses = 1;
}

public class MyPower
{
    public Power power;

    public MyPower(Power p)
    {
        power = p;
    }
}