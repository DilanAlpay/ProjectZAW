using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using UnityEngine.InputSystem;
public class PlayerMovement : BaseCharacterController
{
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

    protected override void HandleInput() {}
}
