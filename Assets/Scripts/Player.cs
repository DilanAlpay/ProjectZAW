using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Character character;
    private Weapon weapon;
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
    public float radius = 12;
    public LayerMask targets;

    void Start()
    {
        controller = GetComponent<PlayerMovement>();

        GameObject model = Instantiate(character.model, transform);
        model.transform.localPosition = Vector3.zero;
        model.transform.rotation = Quaternion.identity;        
        anim = model.GetComponent<Animator>();
        weapon = character.weapon;

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
        Alert();
        HandleShoot();
    }

    public void Alert()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, targets);
        foreach (Collider hit in hits)
        {
            hit.GetComponent<Enemy>()?.Alert(gameObject);
        }
    }

    public void HandleShoot()
    {
        if (Time.time < delayed || shootDir.magnitude == 0) return;
        Shoot();

    }

    public void Shoot()
    {
        anim.Play("Attack");
        weapon.Shoot(Offset,shootDir);
        delayed = Time.time + weapon.rate;
    }

    public void Hurt()
    {
        anim.Play("Hurt");
        controller.movement.ApplyImpulse(-transform.forward * 1000);
    }

    public void Died()
    {
        enabled = false;
        controller.movement.Pause(true);
        input.Player.Disable();

        anim.SetTrigger("dead");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
