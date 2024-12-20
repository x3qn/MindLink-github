using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScripts : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 15f; // Stärke des Sprungs

    // LayerMask für Spieler
    [SerializeField]
    private LayerMask allowedLayers;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prüfen, ob das kollidierende Objekt in den erlaubten Layern ist
        if (((1 << collision.gameObject.layer) & allowedLayers) != 0)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Vertikale Geschwindigkeit auf 0 setzen, um alte Bewegungen zu ignorieren
                rb.velocity = new Vector2(rb.velocity.x, 0);
                // Kraft nach oben anwenden
                rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}

