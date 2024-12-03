using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerScript : MonoBehaviour
{
    private const int Player1Layer = 6; 
    private const int Player2Layer = 7;

    [SerializeField]
    private float restartDelay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfen, ob das Objekt den Layer Player1Layer oder Player2Layer hat
        if (collision.gameObject.layer == Player1Layer || collision.gameObject.layer == Player2Layer)
        {
            // Coroutine starten, um das Level mit Verzögerung neu zu laden
            StartCoroutine(RestartLevelWithDelay());
        }
    }

    private IEnumerator RestartLevelWithDelay()
    {
        // Warte für die angegebene Zeit
        yield return new WaitForSeconds(restartDelay * Time.deltaTime);

        // Level neu laden
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

