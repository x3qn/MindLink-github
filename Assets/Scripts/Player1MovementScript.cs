using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MovementScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool canJump = true;
    float moveInput;
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;
        else
            moveInput = 0f; // Bewegung anhalten, wenn keine Taste gedrückt wird

        // Rigidbody-Geschwindigkeit basierend auf moveInput aktualisieren
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        // Vertikale Bewegung (nur wenn springen erlaubt ist)
        if (canJump && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) // Standard: Leertaste
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Optional: Spieler-Flip basierend auf Bewegungsrichtung
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Rechts
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Links
        }
    }
}
