using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using UnityEngine.InputSystem;
public class PlayerMovement : BaseCharacterController
{
    public Player player;
    public void SetInput(GameControls controls)
    {
        controls.Player.Move.started += OnMove;
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 m = ctx.ReadValue<Vector2>();
        moveDirection = new Vector3(m.x, 0, m.y);
    }

    protected override void Move()
    {
        // Apply movement

        // If using root motion and root motion is being applied (eg: grounded),
        // move without acceleration / deceleration, let the animation takes full control

        var desiredVelocity = CalcDesiredVelocity();

        var currentFriction = isGrounded ? groundFriction : airFriction;
        var currentBrakingFriction = useBrakingFriction ? brakingFriction : currentFriction;

        movement.Move(desiredVelocity, player.Stats.speed, acceleration, deceleration, currentFriction,
            currentBrakingFriction, !allowVerticalMovement);

        // Jump logic

        Jump();
        MidAirJump();
        UpdateJumpTimer();
    }

    protected override void HandleInput() {}
    protected override void UpdateRotation(){}
}
