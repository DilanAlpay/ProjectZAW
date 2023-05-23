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

    public void Shoot(Vector3 pos, Vector3 shootDir)
    {
        Bullet b = Instantiate(bullet, pos, Quaternion.LookRotation(shootDir));
        b.velocity = shootDir.normalized * speed;

        Destroy(b.gameObject, range);
    }
}
