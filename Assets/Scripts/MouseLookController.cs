using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    [SerializeField] private float lookSensitivity = 50f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;
    void Update()
    {
        Vector2 lookInput = CustomInputManager.Instance.GetLookInput();
        transform.Rotate(0, lookInput.x, 0);
    }
}
