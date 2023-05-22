using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Vector3 offset;
    private Animator anim;
    PlayerMovement controller;
    GameControls input;
    Vector3 shootDir = Vector3.zero;
    float delayed = -1;
    public Vector3 Offset
    {
        get
        {
            return transform.position + transform.up * offset.y;
        }
    }
       

    void Start()
    {
        controller = GetComponent<PlayerMovement>();
        anim = GetComponentInChildren<Animator>();

        input = new GameControls();
        input.Player.Enable();

        controller.SetInput(input);

        input.Player.Shoot.started += OnShoot;
        input.Player.Shoot.performed += OnShoot;
        input.Player.Shoot.canceled += OnShoot;
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        Vector2 d = ctx.ReadValue<Vector2>();

        shootDir = new Vector3(d.x, 0, d.y); 
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", controller.movement.velocity.magnitude);

        HandleShoot();
    }

    public void HandleShoot()
    {
        if (Time.time < delayed || shootDir.magnitude == 0) return;
        Shoot();

    }

    public void Shoot()
    {
        anim.Play("Attack");
        Bullet b = Instantiate(weapon.bullet, Offset, Quaternion.LookRotation(shootDir));
        b.velocity =  shootDir.normalized * weapon.speed;
        
        Destroy(b.gameObject, weapon.range);

        delayed = Time.time + weapon.rate;
    }

    public void Hurt()
    {
        anim.Play("Hurt");
        controller.movement.ApplyImpulse(-transform.forward * 1000);
    }
}
