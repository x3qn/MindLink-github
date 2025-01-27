using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    // Der Sound, der abgespielt wird, wenn der Coin eingesammelt wird (optional)
    public AudioClip collectSound;

    // Der Wert des Coins (optional)
    public int coinValue = 1;

    // Referenz zum AudioSource (falls ein Sound abgespielt werden soll)
    private AudioSource audioSource;

    // Referenzen zu den Spieler-Objekten
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        // AudioSource vom Objekt holen oder erstellen
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null && collectSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Überprüfen, ob der Collider zu Player1 oder Player2 gehört
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            // Optional: Punkte hinzufügen (kann an ein GameManager-Skript angebunden werden)
            // GameManager.instance.AddScore(coinValue);

            // Sound abspielen, wenn verfügbar
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Coin deaktivieren oder zerstören
            Destroy(gameObject);
        }
    }
}
