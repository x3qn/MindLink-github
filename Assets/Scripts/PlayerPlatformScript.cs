using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f; //Geschwindigkeit, mit der sich die Plattform nach oben bewegt
    public float targetHeight = 5f; //Zielhoehe, die die Plattform erreichen soll

    private bool player1OnPlatform = false;
    private bool player2OnPlatform = false;

    private Vector3 initialPosition;
    private Animator animator;

    void Start()
    {
        //Speichere die Startposition der Plattform
        initialPosition = transform.position;

        //Hole den Animator von der Plattform
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Animator nicht gefunden! Bitte fuege einen Animator mit dem Parameter 'BothPlayersOnPlatform' hinzu.");
        }
    }

    void Update()
    {
        //Ueberpruefe, ob beide Spieler auf der Plattform sind
        bool bothPlayersOnPlatform = player1OnPlatform && player2OnPlatform;

        //Setze den Animator-Parameter
        if (animator != null)
        {
            animator.SetBool("BothPlayersOnPlatform", bothPlayersOnPlatform);
        }

        //Bewege die Plattform, wenn beide Spieler darauf stehen
        if (bothPlayersOnPlatform)
        {
            MovePlatformUp();
        }
        else
        {
            MovePlatformDown();
        }
    }

    private void MovePlatformUp()
    {
        //Bewege die Plattform nach oben bis zur Zielhoehe
        if (transform.position.y < initialPosition.y + targetHeight)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void MovePlatformDown()
    {
        //Bewege die Plattform zurueck zur Startposition
        if (transform.position.y > initialPosition.y)
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;

            //Stelle sicher, dass sie nicht unter die Startposition sinkt
            if (transform.position.y < initialPosition.y)
            {
                transform.position = initialPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ueberpruefe, ob Spieler 1 die Plattform betritt
        if (other.gameObject.layer == LayerMask.NameToLayer("Player1Layer"))
        {
            player1OnPlatform = true;
        }

        //Ueberpruefe, ob Spieler 2 die Plattform betritt
        if (other.gameObject.layer == LayerMask.NameToLayer("Player2Layer"))
        {
            player2OnPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Ueberpruefe, ob Spieler 1 die Plattform verlaesst
        if (other.gameObject.layer == LayerMask.NameToLayer("Player1Layer"))
        {
            player1OnPlatform = false;
        }

        //Ueberpruefe, ob Spieler 2 die Plattform verlaesst
        if (other.gameObject.layer == LayerMask.NameToLayer("Player2Layer"))
        {
            player2OnPlatform = false;
        }
    }
}
