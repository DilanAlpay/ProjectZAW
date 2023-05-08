using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
public class Player : MonoBehaviour
{
    public Rigidbody bullet;
    public float speed;
    public Vector3 offset;
    public float range;
    private Animator anim;
    BaseCharacterController controller;

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
        controller = GetComponent<BaseCharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("speed", controller.movement.velocity.magnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        anim.Play("Attack");
        Rigidbody b = Instantiate(bullet, Offset, transform.rotation);
        b.velocity = transform.forward * speed;
        
        Destroy(b.gameObject, range);
    }

    public void Hurt()
    {
        anim.Play("Hurt");
        controller.movement.ApplyImpulse(-transform.forward * 1000);
    }
}
