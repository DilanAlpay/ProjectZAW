using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    #region Public Properties
    public CharacterChoice choice;
    public Vector3 offset;
    public float radius = 12;
    public LayerMask targets;
    #endregion

    #region Components
    private Weapon weapon;
    private PlayerMovement controller;
    private Animator anim;
    public PlayerUI ui;
    #endregion

    #region Accessors
    public Vector3 Offset
    {
        get
        {
            return transform.position + transform.up * offset.y;
        }
    }
    public Character Character => choice.character;
    private Stats stats;
    public Stats Stats => stats;
    #endregion

    private GameControls input;
    private Vector3 shootDir = Vector3.zero;
    private float delayed = -1;
    private Item myItem;
    private MyPower myPower;

    void Start()
    {
        controller = GetComponent<PlayerMovement>();

        GameObject model = Instantiate(choice.character.model, transform);
        model.transform.localPosition = Vector3.zero;
        model.transform.rotation = Quaternion.identity;        
        anim = model.GetComponent<Animator>();
        weapon = choice.character.weapon;
        stats = Character.stats;
        stats.Add(weapon.stats);
        SetInput();
    }

    #region Input Handling
    public void SetInput()
    {
        input = new GameControls();
        input.Player.Enable();

        controller.SetInput(input);

        input.Player.Shoot.started += OnShoot;
        input.Player.Shoot.performed += OnShoot;
        input.Player.Shoot.canceled += OnShoot;

        input.Player.Item.started += OnUseItem;
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        Vector2 d = ctx.ReadValue<Vector2>();

        shootDir = new Vector3(d.x, 0, d.y); 
    }

    public void OnUseItem(InputAction.CallbackContext ctx)
    {
        if (!myItem) return;
        myItem.Use(this);
        myItem = null;
        ui.UpdateItem(null);
    }
    #endregion

    #region Modifiers
    public void GiveItem(Item i)
    {
        myItem = i;
        ui.UpdateItem(i);
    }

    public void GivePower(Power p)
    {
        myPower = new MyPower(p);
        ui.UpdatePower(myPower);
    }
    #endregion

    #region Updating
    // Update is called once per frame
    void Update()
    {
        Animate();
        Alert();
        HandleShoot();
    }

    private void Animate()
    {
        anim.SetFloat("speed", controller.movement.velocity.magnitude);
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
    #endregion

    #region Health
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
        Invoke("Reload", 3);
    }
    #endregion

    /// <summary>
    /// Handles the actual shooting using the updating input
    /// </summary>
    public void Shoot()
    {
        anim.transform.rotation = Quaternion.LookRotation(shootDir);
        anim.Play("Attack");
        weapon.Shoot(Offset,shootDir,stats);
        delayed = Time.time + stats.rate;
    }
    
    /// <summary>
    /// Reloads the game when the player dies
    /// </summary>
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}