using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : EnemyBehaviour
{
    public Weapon weapon;
    public Vector3 offset;
    public Vector3 Offset
    {
        get
        {
            return transform.position + transform.up * offset.y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        enemy.Anim.Play("Attack");
        weapon.Shoot(Offset, transform.forward);
        Invoke("Shoot", weapon.rate);
    }
}
