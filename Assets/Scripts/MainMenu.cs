using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameControls controls;
    public Transform marker;
    public List<Character> characters;
    public List<Transform> positions;
    public Vector3 offset;
    public CharacterChoice choice;
    private int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        controls = new GameControls();

        controls.MainMenu.Enable();
        controls.MainMenu.Move.performed += MoveMarker;
        controls.MainMenu.Enter.started += Enter;

        SetCharacter();
    }

    public void MoveMarker(InputAction.CallbackContext ctx)
    {
        current += Mathf.RoundToInt(ctx.ReadValue<Vector2>().x);

        if (current < 0) current = characters.Count - 1;
        else if (current >= characters.Count) current = 0;

        SetCharacter();
    }

    public void SetCharacter()
    {
        choice.character = characters[current];
        marker.position = positions[current].position + offset;
    }

    public void Enter(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(1);
    }

    private void OnDisable()
    {
        controls.MainMenu.Disable();
    }
}
