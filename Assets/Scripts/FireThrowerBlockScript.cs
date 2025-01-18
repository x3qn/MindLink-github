using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireThrowerBlockScript : MonoBehaviour
{
    public Animator animator;  // Referenz auf den Animator
    public float interval = 2; // Intervall zwischen den Zustandswechseln

    private bool isThrowing = false; // Aktueller Zustand

    private void Start()
    {
        // Coroutine starten
        StartCoroutine(SwitchThrowingState());
    }

    private IEnumerator SwitchThrowingState()
    {
        while (true)
        {
            // Zustand umkehren
            isThrowing = !isThrowing;

            // Zustand auf den Animator setzen
            animator.SetBool("IsThrowing", isThrowing);

            // Warten, bevor der Zustand erneut gewechselt wird
            yield return new WaitForSeconds(interval);
        }
    }
}
