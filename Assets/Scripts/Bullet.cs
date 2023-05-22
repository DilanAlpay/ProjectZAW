using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Dangerous
{
    public Vector3 velocity { set { GetComponent<Rigidbody>().velocity = value; } }
    public override void Collide(GameObject collision)
    {
        base.Collide(collision);
        Destroy(gameObject);
    }
}
