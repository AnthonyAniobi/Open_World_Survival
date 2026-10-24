using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    void Update()
    {
        Vector2 lookInput = CustomInputManager.Instance.GetLookInput();
        transform.Rotate(0, lookInput.x, 0);
    }
}
