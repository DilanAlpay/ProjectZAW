using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBoost : MonoBehaviour
{
    private Player player;
    private IE_Stat effect;

    public void Init(Player p, IE_Stat e, float dur)
    {
        player = p;
        effect = e;
        player.Stats.Add(effect.stats);
        Debug.Log(player.Stats.speed + " is our new speed");
        Invoke("Revert", dur);
    }

    public void Revert()
    {
        player.Stats.Subtract(effect.stats);
        Destroy(this);
    }

}
