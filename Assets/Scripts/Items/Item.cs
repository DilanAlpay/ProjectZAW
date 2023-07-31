using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public List<ItemEffect> effects;
    public Vector3 offset;
    public float duration = -1;
    public bool orient = false;
    public bool attach = false;
    public Reaction<Player> onUse;

    public void Use(Player player)
    {
        foreach (ItemEffect effect in effects)
        {
            ItemEffect obj = Instantiate(effect, player.transform.position, Quaternion.identity);
            if (orient) obj.transform.rotation = player.transform.rotation;
            if (attach) obj.transform.parent = player.transform;
            if (duration >= 0) Destroy(obj, duration);
            effect.Use(player);
        }
    }
}
