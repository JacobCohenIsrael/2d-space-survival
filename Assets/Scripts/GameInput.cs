using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler FireStartedEvent;
    public event EventHandler FireCanceledEvent;

    public event EventHandler PullStartedEvent;
    public event EventHandler PullCanceledEvent;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Ship.Enable();
    }

    private void Start()
    {
        playerInputActions.Ship.Fire.started += OnFireStartedEvent;
        playerInputActions.Ship.Fire.canceled += OnFireCanceledEvent;

        playerInputActions.Ship.Pull.started += OnPullStartedEvent;
        playerInputActions.Ship.Pull.canceled += OnPullCanceledEvent;
    }

    private void OnDestroy()
    {
        playerInputActions.Ship.Fire.performed -= OnFireStartedEvent;
        playerInputActions.Ship.Fire.canceled -= OnFireCanceledEvent;
        
        playerInputActions.Ship.Pull.started -= OnPullStartedEvent;
        playerInputActions.Ship.Pull.canceled -= OnPullCanceledEvent;
    }

    public Vector2 GetShipVectorNormalized()
    {
        return playerInputActions.Ship.Move.ReadValue<Vector2>().normalized;
    }

    protected virtual void OnFireStartedEvent(InputAction.CallbackContext callbackContext)
    {
        FireStartedEvent?.Invoke(this, EventArgs.Empty);
    }
    
    protected virtual void OnFireCanceledEvent(InputAction.CallbackContext ctx)
    {
        FireCanceledEvent?.Invoke(this, EventArgs.Empty);
    }
    
    protected virtual void OnPullStartedEvent(InputAction.CallbackContext callbackContext)
    {
        PullStartedEvent?.Invoke(this, EventArgs.Empty);
    }
    
    protected virtual void OnPullCanceledEvent(InputAction.CallbackContext ctx)
    {
        PullCanceledEvent?.Invoke(this, EventArgs.Empty);
    }
}
