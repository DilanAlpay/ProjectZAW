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
    public Animator anim;
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
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("speed", controller.movement.velocity.magnitude);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Shoot(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Shoot(Vector3.right);
        }


    }

    public void Shoot(Vector3 direction)
    {
        anim.Play("Attack");
        Rigidbody b = Instantiate(bullet, Offset, Quaternion.identity);
        b.velocity = direction * speed;
        Destroy(b.gameObject, range);
    }

}
