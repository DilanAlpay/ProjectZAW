using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    protected Player player;

    public virtual void Use(Player p)
    {
        player = p;
    }
}
