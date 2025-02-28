using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleEnemyScript : MonoBehaviour
{
    [Header("Bewegungseinstellungen")]
    public float speed = 2f; //Geschwindigkeit des Slime
    public Transform groundCheck; //Punkt zum Ueberpruefen des Bodenkontakts
    public float groundCheckRadius = 0.1f; //Radius des Ground-Check-Kreises
    public LayerMask wallLayer; //Layer, auf dem sich die Waende befinden

    [Header("Spieler-Interaktionen")]
    public float restartDelay = 1f; //Verzoegerung, bevor das Level neu geladen wird

    private Rigidbody2D rb;
    private bool movingRight = true;
    private bool isDead = false; //Status des Slime

    private const int Player1Layer = 6; //Layer fuer Spieler 1
    private const int Player2Layer = 7; //Layer fuer Spieler 2

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; //Slime bewegt sich nicht, wenn tot 

        //Bewegung in die aktuelle Richtung
        rb.velocity = new Vector2(movingRight ? speed : -speed, rb.velocity.y);

        //UeberprUefen, ob Wand vor Slime ist
        if (IsHittingWall())
        {
            Flip();
        }
    }

    private bool IsHittingWall()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, direction, groundCheckRadius, wallLayer);

        return hit.collider != null;
    }

    private void Flip()
    {
        //Richtung umkehren
        movingRight = !movingRight;

        //Sprite horizontal spiegeln
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ist kollidierte Objekt ein Spieler?
        if (collision.gameObject.layer == Player1Layer || collision.gameObject.layer == Player2Layer)
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                //Spieler kommt von oben --> Slime stirbt
                if (playerRb.velocity.y < 0)
                {
                    Die();
                    playerRb.velocity = new Vector2(playerRb.velocity.x, 5f); //Spieler springt hoch
                }
                //Spieler kommt nicht von oben --> Spieler stirbt
                else
                {
                    StartCoroutine(RestartLevelWithDelay());
                }
            }
        }
    }

    private void Die()
    {
        isDead = true; //Status des Slime auf "tot" setzen

        Destroy(gameObject, 0.2f); //Slime verschwindet nach kurzer Zeit
    }

    private IEnumerator RestartLevelWithDelay()
    {
        //Warte fuer die angegebene Zeit
        yield return new WaitForSeconds(restartDelay);

        //Level neu laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //GroundCheck sichtbar machen
    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}