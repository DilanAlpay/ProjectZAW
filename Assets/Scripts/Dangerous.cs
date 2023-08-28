using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangerous : MonoBehaviour
{
    public float damage = 1;
    public float Damage
    {
        set
        {
            damage = value;
        }
    }
    public DamageType damageType;

    private void OnCollisionEnter(Collision collision)
    {
        Collide(collision.gameObject);

    }

    public virtual void Collide(GameObject collision)
    {
        Health hit = collision.gameObject.GetComponentInParent<Health>();
        if (hit)
        {
            hit.Hurt(new Damage(damage, damageType, transform));
        }
    }
}
