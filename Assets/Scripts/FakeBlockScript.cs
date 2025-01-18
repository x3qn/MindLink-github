using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlockScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask allowedLayers; // LayerMask für Player1Layer und Player2Layer

    private Rigidbody2D rb; // Rigidbody2D des Fake Blocks
    private bool player1Inside = false; // Überprüft, ob Player1 im Collider ist
    private bool player2Inside = false; // Überprüft, ob Player2 im Collider ist
    private bool isTriggered = false; // Verhindert mehrfaches Auslösen

    private void Awake()
    {
        // Holen des Rigidbody2D vom GameObject
        rb = GetComponent<Rigidbody2D>();

        // Sicherstellen, dass der Rigidbody2D auf Static ist
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Prüfen, ob Player1 den Trigger berührt
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player1Layer"))
        {
            player1Inside = true;
        }

        // Prüfen, ob Player2 den Trigger berührt
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player2Layer"))
        {
            player2Inside = true;
        }

        // Wenn beide Spieler im Trigger sind und der Block nicht ausgelöst wurde
        if (player1Inside && player2Inside && !isTriggered)
        {
            isTriggered = true; // Block als ausgelöst markieren
            Debug.Log("Beide Spieler im Trigger! Umschalten in 3 Sekunden...");

            // 3 Sekunden Verzögerung und dann Rigidbody auf Dynamic setzen
            Invoke(nameof(SwitchToDynamic), 2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Prüfen, ob Player1 den Trigger verlässt
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player1Layer"))
        {
            player1Inside = false;
        }

        // Prüfen, ob Player2 den Trigger verlässt
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player2Layer"))
        {
            player2Inside = false;
        }
    }

    private void SwitchToDynamic()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Schalte auf Dynamic um
            Debug.Log("Rigidbody ist jetzt Dynamic!");

            // Block nach weiteren 3 Sekunden zerstören
            Invoke(nameof(DestroyBlock), 1f);
        }
    }

    private void DestroyBlock()
    {
        Debug.Log("Fake Block wird zerstört!");
        Destroy(gameObject); // Entfernt den Fake Block aus der Szene
    }
}
