using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerControls controls;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2f;

    [Header("Look Settings")]
    [SerializeField] private float mouseSensitivity = 15f;
    [SerializeField] private float xRotationLimit = 85f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private float xRotation = 0f;
    private Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new PlayerControls();

        if (cameraTransform == null)
        {
            Debug.LogError($"{nameof(PlayerMovement)} requires a camera transform.", this);
            enabled = false;
            return;
        }

        controls.Player.Jump.performed += OnJumpPerformed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        controls?.Enable();
    }

    private void OnDisable()
    {
        controls?.Disable();
    }

    private void OnDestroy()
    {
        if (controls == null)
        {
            return;
        }

        controls.Player.Jump.performed -= OnJumpPerformed;
        controls.Dispose();
    }

    private void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        moveInput = controls.Player.Move.ReadValue<Vector2>();

        lookInput = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);

        Vector3 moveDirection = (transform.forward * moveInput.y + transform.right * moveInput.x).normalized;

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        controller.Move(moveSpeed * Time.deltaTime * moveDirection);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnJumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Jump();
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
