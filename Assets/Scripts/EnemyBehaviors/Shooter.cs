using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : EnemyBehaviour
{
    public Weapon weapon;
    public float startDelay;
    public Vector3 offset;
    public Vector3 Offset
    {
        get
        {
            return transform.position + (transform.up * offset.y) + (transform.forward * offset.z);
        }
    }

    public override void Activate(GameObject p)
    {
        base.Activate(p);
        Invoke("Shoot", startDelay);
    }

    public void Shoot()
    {
        enemy.Anim.Play("Shoot");
        weapon.Shoot(Offset, transform.forward);
        Invoke("Shoot", weapon.rate);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(Offset, 0.25f);
    }
}
