using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerActions.IGameplayActions
{
    private PlayerActions playerActions;
    private static InputManager instance;
    public Vector2 moveInput { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances");
        }
        instance = this;
    }


    void OnEnable()
    {
        playerActions = new PlayerActions();
        playerActions.Gameplay.SetCallbacks(this);
        playerActions.Gameplay.Enable();
    }

    void OnDisable()
    {
        playerActions.Gameplay.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

}
