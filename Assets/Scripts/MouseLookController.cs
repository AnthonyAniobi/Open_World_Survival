using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    [SerializeField] private float lookSensitivity = 50f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 lookInput = CustomInputManager.Instance.GetLookInput();
        xRotation -= lookInput.y * lookSensitivity * Time.deltaTime;
        yRotation += lookInput.x * lookSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);
        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0f);
    }
}
