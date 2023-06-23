using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler FireEvent;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Ship.Enable();
    }

    private void Start()
    {
        playerInputActions.Ship.Fire.performed += OnFireEvent;
    }

    private void OnDestroy()
    {
        playerInputActions.Ship.Fire.performed -= OnFireEvent;

    }

    public Vector2 GetShipVectorNormalized()
    {
        return playerInputActions.Ship.Move.ReadValue<Vector2>().normalized;
    }

    protected virtual void OnFireEvent(InputAction.CallbackContext callbackContext)
    {
        FireEvent?.Invoke(this, EventArgs.Empty);
    }
}
