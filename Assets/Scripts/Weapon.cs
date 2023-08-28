using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Bullet bullet;
    public Stats stats;

    public void Shoot(Vector3 pos, Vector3 shootDir, Stats shooter = null)
    {
        Bullet b = Instantiate(bullet, pos, Quaternion.LookRotation(shootDir));

        float speed = shooter != null ? shooter.bulletSpeed : stats.bulletSpeed;         
        b.velocity = shootDir.normalized * speed;

        float damage= shooter != null ? shooter.damage : stats.damage;
        b.Damage = damage;

        float range = shooter != null ? shooter.range : stats.range;
        Destroy(b.gameObject, range);
    }



}
