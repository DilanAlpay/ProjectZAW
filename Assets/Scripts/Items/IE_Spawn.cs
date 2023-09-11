using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_Spawn : ItemEffect
{
    public GameObject obj;
    public Vector3 offset;
    public float lifetime = 0;


    public override void Use(Item i, Player p)
    {
        base.Use(i, p);
    }
}
