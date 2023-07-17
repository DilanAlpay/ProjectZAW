using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A power is an item you can use to do a super attack
/// </summary>
[CreateAssetMenu(menuName ="Power")]
public class Power : Weapon
{
    public Sprite icon;
    public int uses = 1;
    public Response<Player> onUse;


    public void Use(Player player)
    {

    }

    public void ChangeStat(Player player)
    {

    }

    /// <summary>
    /// Spawns an object wherever the Player is
    /// </summary>
    /// <param name="player"></param>
    /// <param name="obj"></param>
    public void Spawn(Player player, GameObject obj)
    {
        GameObject newObj = Instantiate(obj, player.transform.position, Quaternion.identity);
    }
}

/// <summary>
/// An object reference to a power that we currently have
/// </summary>
public class MyPower
{
    public Power power;

    public MyPower(Power p)
    {
        power = p;
    }

    
}