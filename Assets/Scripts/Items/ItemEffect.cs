using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect 
{
    protected Player player;
    protected Item item;

    public virtual void Use(Item i, Player p)
    {
        item = i;
        player = p;
    }
}
