using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Dangerous
{
    public override void Collide(GameObject collision)
    {
        base.Collide(collision);
        Destroy(gameObject);
    }
}
