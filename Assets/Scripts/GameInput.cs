using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Ship.Enable();
    }

    public Vector2 GetShipVectorNormalized()
    {
        return playerInputActions.Ship.Move.ReadValue<Vector2>().normalized;
    }
}
