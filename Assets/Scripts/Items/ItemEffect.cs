using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : ScriptableObject
{
    public Reaction<Player> onUse;

    public virtual void Use(Player player)
    {
        onUse.Invoke(player);
    }
}
