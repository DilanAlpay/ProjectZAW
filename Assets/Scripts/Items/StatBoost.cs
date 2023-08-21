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
        Invoke("Revert", dur);
    }

    public void Revert()
    {
        player.Stats.Subtract(effect.stats);
    }

}
