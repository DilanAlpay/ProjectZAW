using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_Stat : ItemEffect
{
    public Stats stats;

    public void Add()
    {
        player.Stats.Add(stats);
    }

    public void Subtract()
    {
        player.Stats.Subtract(stats);
    }
}
