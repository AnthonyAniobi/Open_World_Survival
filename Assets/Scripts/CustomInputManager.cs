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
        inputMap = InputSystem.actions.FindActionMap("Account");
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
        return inputMap.FindAction("Jump").WasPressedThisFrame();
    }

    public bool GetInteractInput()
    {
        return inputMap.FindAction("Interact").WasPressedThisFrame();
    }

    public bool FlipCameraInput()
    {
        return inputMap.FindAction("FlipCamera").WasPressedThisFrame();
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
