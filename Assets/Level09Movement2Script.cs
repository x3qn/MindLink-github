using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level09Movement2Script : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit des Spielers
    public float jumpForce = 10f; // Sprungkraft
    public LayerMask groundLayer; // Layer, der den Boden repr�sentiert
    public Transform groundCheck; // Punkt, um zu pr�fen, ob der Spieler am Boden ist
    public float groundCheckRadius = 0.2f; // Radius der Bodenerkennung

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �berpr�fen, ob der Spieler am Boden ist
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Sprung-Eingabe
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }

        // Setze den Animationsparameter "Speed" basierend auf der Bewegung
        animator.SetFloat("Speed", moveSpeed);
    }

    void FixedUpdate()
    {
        // Spieler bewegt sich konstant nach rechts durch direkte Positions�nderung
        transform.position += Vector3.right * moveSpeed * Time.fixedDeltaTime;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnDrawGizmos()
    {
        // Zeichnet den GroundCheck-Radius zur visuellen Hilfe
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}