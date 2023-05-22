using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Bullet bullet;
    public float speed;
    public float range;
    public float rate;
}
