using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public List<ItemEffect> effects;
    public Sprite icon;

    public void Use(Player player)
    {
        foreach (ItemEffect effect in effects)
        {
            effect.Use(player);
        }
    }
}
