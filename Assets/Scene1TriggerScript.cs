using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1TriggerScript : MonoBehaviour
{
    private bool player1InZone = false;
    private bool player2InZone = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfen, welcher Spieler den Trigger betreten hat
        if (other.CompareTag("Player1"))
        {
            player1InZone = true;
        }
        else if (other.CompareTag("Player2"))
        {
            player2InZone = true;
        }

        // Starten der Coroutine, wenn beide Spieler im Collider sind
        if (player1InZone && player2InZone)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Überprüfen, welcher Spieler den Trigger verlassen hat
        if (other.CompareTag("Player1"))
        {
            player1InZone = false;
        }
        else if (other.CompareTag("Player2"))
        {
            player2InZone = false;
        }

        // Abbrechen der Coroutine, falls einer der Spieler den Collider verlässt
        if (!player1InZone || !player2InZone)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator LoadNextScene()
    {
        // Berechne den Index der nächsten Szene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Überprüfen, ob der Index gültig ist
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Keine weitere Szene verfügbar!");
        }

        // Füge diese Zeile hinzu, um den Fehler zu vermeiden
        yield return null;
    }
}