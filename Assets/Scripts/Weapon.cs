using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Bullet bullet;
    public Stats stats;

    public void Shoot(Vector3 pos, Vector3 shootDir)
    {
        Bullet b = Instantiate(bullet, pos, Quaternion.LookRotation(shootDir));
        b.velocity = shootDir.normalized * stats.bulletSpeed;
        Destroy(b.gameObject, stats.range);
    }
}
