using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float maxMoveSpeed = 5f;
    [SerializeField] private float acceleration = 25f;
    [SerializeField] private float deceleration = 35f;

    private Rigidbody2D rb;
    private float moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = 0f;

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = -1f;
        }

        if (Keyboard.current.dKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = 1f;
        }
    }

    private void FixedUpdate()
    {
        float targetSpeed = moveInput * maxMoveSpeed;

        float rate = Mathf.Abs(targetSpeed) > 0.01f
            ? acceleration
            : deceleration;

        float newXVelocity = Mathf.MoveTowards(
            rb.linearVelocity.x,
            targetSpeed,
            rate * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector2(
            newXVelocity,
            rb.linearVelocity.y
        );
    }
}