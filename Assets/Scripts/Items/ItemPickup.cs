using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : PickUp
{
    public Item item;

    public override void Collect(Player player)
    {
        player.GiveItem(item);
        base.Collect(player);

    }
}
