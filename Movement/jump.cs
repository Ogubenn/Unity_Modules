using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [Tooltip("Zıplama kuvveti")]
    [SerializeField] private float jumpForce = 7f;

    [Tooltip("Üzerinde zıplanabilen zemin katmanları")]
    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D rb;
    private BoxCollider2D col2d;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            jumpAction();
    }

    private void jumpAction()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            col2d.bounds.center, // Merkez noktası
            col2d.bounds.size,  // Boyut
            0f,            // Açı
            Vector2.down,   // Yön
            0.1f,        // Mesafe
            jumpableGround // Çarpışacağı katmanlar
        );

        return hit.collider != null;
    }
}
