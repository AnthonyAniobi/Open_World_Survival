using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputManager : MonoBehaviour
{
    public static CustomInputManager Instance { get; private set; }

    private InputActionMap inputMap;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        inputMap = InputSystem.actions.FindActionMap("Player");
        inputMap.Enable();
    }

    public Vector2 GetLookInput()
    {
        return inputMap.FindAction("Look").ReadValue<Vector2>();
    }

    public Vector2 GetMoveInput()
    {
        return inputMap.FindAction("Move").ReadValue<Vector2>();
    }

    public bool GetJumpInput()
    {
        return inputMap.FindAction("Jump").triggered;
    }
}
