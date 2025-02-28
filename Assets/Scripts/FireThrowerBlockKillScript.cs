using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireThrowerBlockKillScript : MonoBehaviour
{
    private const int Player1Layer = 6;
    private const int Player2Layer = 7;

    [SerializeField]
    private Animator animator; //Referenz auf den Animator

    [SerializeField]
    private BoxCollider2D boxCollider; //Der Collider, der aktiviert/deaktiviert wird

    private bool isThrowing = false; //Zustand --> Werfen oder nicht

    private void Start()
    {
        //Startet den Wechsel der Animationen und Zustände alle 2 Sekunden
        StartCoroutine(SwitchThrowingState());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ueberpruefen, ob das Objekt den Layer Player1Layer oder Player2Layer hat
        if (collision.gameObject.layer == Player1Layer || collision.gameObject.layer == Player2Layer)
        {
            //Level sofort neu laden
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private IEnumerator SwitchThrowingState()
    {
        while (true)
        {
            //Zustand umkehren
            isThrowing = !isThrowing;

            //Setze den Zustand im Animator
            animator.SetBool("IsThrowing", isThrowing);

            //Collider aktivieren, wenn IsThrowing true ist, sonst deaktivieren
            boxCollider.enabled = isThrowing;

            //Warte für 2 Sekunden vor dem naechsten Wechsel
            yield return new WaitForSeconds(3f);
        }
    }
}
