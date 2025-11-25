using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movementWASD2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Karakterin ileri hareket hızı")]
    public float forwardSpeed = 10f;

    [Tooltip("Karakterin geri hareket hızı")]
    public float backwardSpeed = 5f;

    [Tooltip("Karakterin yatay hareket hızı")]
    public float horizontalSpeed = 4f;

    [Header("Ayarlar")]
    [Tooltip("Çapraz hareket ederken hız artışını engeller.")]
    public bool normalizeDiagonalMovement = true;

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            input.y += 1f;

        if (Input.GetKey(KeyCode.S))
            input.y -= 1f;

        if (Input.GetKey(KeyCode.A))
            input.x -= 1f;

        if (Input.GetKey(KeyCode.D))
            input.x += 1f;

        if (normalizeDiagonalMovement && input.sqrMagnitude > 1f)
            input = input.normalized;

        float xMove = input.x * horizontalSpeed;
        float yMove = 0f;

        if (input.y > 0)
            yMove = forwardSpeed;
        else if (input.y < 0)
            yMove = -backwardSpeed;

        Vector3 movement = new Vector3(xMove, yMove, 0f) * Time.deltaTime;
        transform.position += movement;
    }
}
