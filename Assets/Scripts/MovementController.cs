using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private float gravity = -9.81f;
    private CharacterController characterController;
    private float verticalVelocity = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 moveInput = CustomInputManager.Instance.GetMoveInput();
        bool jumpInput = CustomInputManager.Instance.GetJumpInput();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        if (jumpInput && characterController.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(gravity)); // Adjust jump height as needed
        }
        if (characterController.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f; // Small negative value to keep the player grounded
        }
        verticalVelocity += gravity * Time.deltaTime;
        moveDirection = moveDirection * moveSpeed * Time.deltaTime;
        moveDirection.y += verticalVelocity * Time.deltaTime;

        characterController.Move(moveDirection);
    }
}
