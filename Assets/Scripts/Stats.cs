using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    /// <summary>
    /// How much damage you deal
    /// </summary>
    public float damage;

    /// <summary>
    /// How fast the player moves
    /// </summary>
    public float speed;

    /// <summary>
    /// How far the enemy moves back when hit
    /// </summary>
    public float force;

    /// <summary>
    /// How quickly you attack
    /// </summary>
    public float rate;

    public void ChangeStat(Stat stat, float amount)
    {
        switch (stat)
        {
            case Stat.DAMAGE:
                damage += amount;
                break;
            case Stat.SPEED:
                speed += amount;
                break;
            case Stat.FORCE:
                force += amount;
                break;
            case Stat.RATE:
                rate += amount;
                break;
        }
    }

    public float GetStat(Stat stat)
    {
        switch (stat)
        {
            case Stat.DAMAGE:
                return damage;
            case Stat.SPEED:
                return speed;
            case Stat.FORCE:
                return force;
            case Stat.RATE:
                return rate;
            default:
                return 0;
        }
    }
}

public enum Stat
{
    DAMAGE,
    SPEED,
    FORCE,
    RATE
}
