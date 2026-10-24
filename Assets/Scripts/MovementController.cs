using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 moveInput = CustomInputManager.Instance.GetMoveInput();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
