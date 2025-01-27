using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleEnemyScript : MonoBehaviour
{
    [Header("Bewegungseinstellungen")]
    public float speed = 2f; // Geschwindigkeit des Slime
    public Transform groundCheck; // Punkt zum Überprüfen des Bodenkontakts
    public float groundCheckRadius = 0.1f; // Radius des Ground-Check-Kreises
    public LayerMask wallLayer; // Layer, auf dem sich die Wände befinden

    [Header("Spieler-Interaktionen")]
    public float restartDelay = 1f; // Verzögerung, bevor das Level neu geladen wird

    private Rigidbody2D rb;
    private bool movingRight = true;
    private bool isDead = false; // Status des Slime

    private const int Player1Layer = 6; // Layer für Spieler 1
    private const int Player2Layer = 7; // Layer für Spieler 2

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; // Slime bewegt sich nicht, wenn er tot ist

        // Bewegung in die aktuelle Richtung
        rb.velocity = new Vector2(movingRight ? speed : -speed, rb.velocity.y);

        // Überprüfen, ob vor dem Slime eine Wand ist
        if (IsHittingWall())
        {
            Flip();
        }
    }

    private bool IsHittingWall()
    {
        // Prüfen, ob der BodenCheck-Punkt auf eine Wand trifft
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, direction, groundCheckRadius, wallLayer);

        return hit.collider != null;
    }

    private void Flip()
    {
        // Richtung umkehren
        movingRight = !movingRight;

        // Sprite horizontal spiegeln (optional)
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfen, ob das kollidierte Objekt ein Spieler ist
        if (collision.gameObject.layer == Player1Layer || collision.gameObject.layer == Player2Layer)
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                // Spieler kommt von oben: Slime stirbt
                if (playerRb.velocity.y < 0)
                {
                    Die();
                    playerRb.velocity = new Vector2(playerRb.velocity.x, 5f); // Spieler springt hoch
                }
                // Spieler kommt nicht von oben: Spieler stirbt
                else
                {
                    StartCoroutine(RestartLevelWithDelay());
                }
            }
        }
    }

    private void Die()
    {
        isDead = true; // Status des Slime auf "tot" setzen

        // Optional: Animation oder Effekt beim Sterben
        Destroy(gameObject, 0.2f); // Slime verschwindet nach kurzer Zeit
    }

    private IEnumerator RestartLevelWithDelay()
    {
        // Warte für die angegebene Zeit
        yield return new WaitForSeconds(restartDelay);

        // Level neu laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Ground-Check sichtbar machen
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}