using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player1MovementScript2 : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public float jumpForce;
    public float jumpDelay = 0.5f; 
    public bool canJump = true;

    private bool isGrounded;
    private bool jumpReady = true; //Steuerung des Sprung-Delays
    float moveInput;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput * moveSpeed));

        //GroundCheck
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //Horizontale Bewegung
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;
        else
            moveInput = 0f; //Bewegung anhalten

        //Rigidbody-Geschwindigkeit basierend auf moveInput aktualisieren
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //Vertikale Bewegung
        if (canJump && isGrounded && jumpReady && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
            StartCoroutine(SprungCooldown()); //Starte Sprung-Delay
        }

        if (isGrounded && !wasGrounded) //Spieler ist gerade gelandet
        {
            OnLanding();
        }

        //Spieler-Flip basierend auf Bewegungsrichtung
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); //Rechts
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //Links
        }
    }
    void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    //Ground-Check sichtbar machen
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    //Coroutine fuer den Sprung-Delay
    private IEnumerator SprungCooldown()
    {
        jumpReady = false; //Sprung voruebergehend gesperrt
        yield return new WaitForSeconds(jumpDelay); //Warte Zeit fuer den Delay
        jumpReady = true; //Sprung wieder erlaubt
    }
}

