using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dangerous : MonoBehaviour
{
    public int damage = 1;
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
