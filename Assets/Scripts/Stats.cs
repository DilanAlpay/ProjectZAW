using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
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

    /// <summary>
    /// How fast the bullet moves
    /// </summary>
    public float bulletSpeed;

    /// <summary>
    /// How long the bullet is on the screen for
    /// </summary>
    public float range;

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
            case Stat.BULLETSPEED:
                bulletSpeed += amount;
                break;
            case Stat.RANGE:
                range += amount;
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
            case Stat.BULLETSPEED:
                return bulletSpeed;
            case Stat.RANGE:
                return range;
            default:
                return 0;
        }
    }

    public void Add(Stats s)
    {
        damage += s.damage;
        speed += s.speed;
        force += s.force;
        rate += s.rate;
        bulletSpeed -= s.bulletSpeed;
        range += s.range;
    }

    public void Subtract(Stats s)
    {
        damage -= s.damage;
        speed -= s.speed;
        force -= s.force;
        rate -= s.rate;
        bulletSpeed -= s.bulletSpeed;
        range -= s.range;
    }
}

public enum Stat
{
    DAMAGE,
    SPEED,
    FORCE,
    RATE,
    BULLETSPEED,
    RANGE,
}
