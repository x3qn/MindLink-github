using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlockScript : MonoBehaviour
{
    private Rigidbody2D rb; //Rigidbody2D des Fake Blocks
    private bool player1Inside = false; //Ueberprueft ob Player1 im Collider ist
    private bool player2Inside = false; //Ueberprueft ob Player2 im Collider ist
    private bool isTriggered = false; //Verhindert mehrfaches Auslösen

    private GameObject sprite1; //"1"
    private GameObject sprite2; //"2"

    private void Awake()
    {
        //
        //Holen des Rigidbody2D vom GameObject
        rb = GetComponent<Rigidbody2D>();

        //Sicherstellen, dass der Rigidbody2D auf Static ist
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        //Finden von "1" und "2"
        sprite1 = transform.Find("1")?.gameObject;
        sprite2 = transform.Find("2")?.gameObject;

        //Sicherstellen, dass die Sprites initialisiert sind
        if (sprite1 == null || sprite2 == null)
        {
            Debug.LogError("Die Kinder '1' und '2' konnten nicht gefunden werden. Bitte ueberpruefen Sie die Hierarchie.");
        }

        //Initiale Zustände der Sprites setzen
        UpdateSpriteState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pruefen, ob Player1 den Trigger beruehrt
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player1Layer"))
        {
            player1Inside = true;
        }

        //Pruefen, ob Player2 den Trigger beruehrt
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player2Layer"))
        {
            player2Inside = true;
        }

        //Update der Sprite-Zustaende
        UpdateSpriteState();

        //Wenn beide Spieler im Trigger sind und der Block nicht ausgeloest wurde
        if (player1Inside && player2Inside && !isTriggered)
        {
            isTriggered = true; //Block als ausgeloest markieren
            Debug.Log("Beide Spieler im Trigger! Umschalten in 3 Sekunden...");

            //1 Sekunden Verzoegerung und dann Rigidbody auf Dynamic setzen
            Invoke(nameof(SwitchToDynamic), 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Pruefen, ob Player1 den Trigger verlaesst
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player1Layer"))
        {
            player1Inside = false;
        }

        //Pruefen, ob Player2 den Trigger verlaesst
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player2Layer"))
        {
            player2Inside = false;
        }

        //Update der Sprite-Zustaende
        UpdateSpriteState();
    }

    private void UpdateSpriteState()
    {
        if (sprite1 == null || sprite2 == null) return;

        if (player1Inside && player2Inside)
        {
            //Beide Spieler im Bereich --> Deaktiviere beide Sprites
            sprite1.SetActive(false);
            sprite2.SetActive(false);
        }
        else if (player1Inside || player2Inside)
        {
            //Einer der Spieler im Bereich --> Aktiviere Sprite "1", deaktiviere Sprite "2"
            sprite1.SetActive(true);
            sprite2.SetActive(false);
        }
        else
        {
            //Keiner im Bereich --> Aktiviere Sprite "2", deaktiviere Sprite "1"
            sprite1.SetActive(false);
            sprite2.SetActive(true);
        }
    }

    private void SwitchToDynamic()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; //Schalte auf Dynamic um
            Debug.Log("Rigidbody ist jetzt Dynamic!");

            //Block nach weiteren 3 Sekunden zerstoeren
            Invoke(nameof(DestroyBlock), 1f);
        }
    }

    private void DestroyBlock()
    {
        Debug.Log("Fake Block wird zerstört!");
        Destroy(gameObject); //Entfernt den Fake Block aus der Szene
    }
}