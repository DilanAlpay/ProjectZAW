using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody bullet;
    public float speed;
    public Vector3 offset;
    public float range;

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
        Rigidbody b = Instantiate(bullet, Offset, Quaternion.identity);
        b.velocity = direction * speed;
        Destroy(b.gameObject, range);
    }

}
