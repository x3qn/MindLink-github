using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBirdScript : MonoBehaviour
{
    //[Header("Bewegungseinstellungen")]
    //public float speed = 2f; //Geschwindigkeit des Vogels
    //public Transform[] waypoints; //Wegpunkte für die Bewegung
    //public float waypointTolerance = 0.1f; //Toleranz, um einen Wegpunkt zu erreichen

    //[Header("Spieler-Interaktionen")]
    //public float restartDelay = 1f; //Verzoegerung, bevor das Level neu geladen wird

    //private Rigidbody2D rb;
    //private int currentWaypointIndex = 0;
    //private bool isDead = false; //Status des Vogels

    //private const int Player1Layer = 6; //Layer für Spieler 1
    //private const int Player2Layer = 7; //Layer für Spieler 2

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();

    //    if (waypoints.Length == 0)
    //    {
    //        Debug.LogError("Keine Wegpunkte zugewiesen! Bitte füge Wegpunkte hinzu.");
    //    }
    //}

    //void Update()
    //{
    //    if (isDead || waypoints.Length == 0) return; //Vogel bewegt sich nicht, wenn tot ist oder keine Wegpunkte existieren

    //    // ewegung zum aktuellen Wegpunkt
    //    Transform targetWaypoint = waypoints[currentWaypointIndex];
    //    Vector2 direction = (targetWaypoint.position - transform.position).normalized;
    //    rb.velocity = direction * speed;

    //    //Ueberpruefen, ob der Wegpunkt erreicht wurde
    //    if (Vector2.Distance(transform.position, targetWaypoint.position) < waypointTolerance)
    //    {
    //        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; //Zum naechsten Wegpunkt wechseln
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Ueberpruefen, ob das kollidierte Objekt ein Spieler ist
    //    if (collision.gameObject.layer == Player1Layer || collision.gameObject.layer == Player2Layer)
    //    {
    //        Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

    //        if (playerRb != null)
    //        {
    //            //Spieler kommt von oben: Vogel stirbt
    //            if (playerRb.velocity.y < 0)
    //            {
    //                Die();
    //                playerRb.velocity = new Vector2(playerRb.velocity.x, 5f); //Spieler springt hoch
    //            }
    //            //Spieler kommt nicht von oben: Spieler stirbt
    //            else
    //            {
    //                StartCoroutine(RestartLevelWithDelay());
    //            }
    //        }
    //    }
    //}

    //private void Die()
    //{
    //    isDead = true; //Status des Vogels auf "tot" setzen

    //    Destroy(gameObject, 0.2f); //Vogel verschwindet nach kurzer Zeit
    //}

    //private IEnumerator RestartLevelWithDelay()
    //{
    //    //Warte für die angegebene Zeit
    //    yield return new WaitForSeconds(restartDelay);

    //    //Level neu laden
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    ////Wegpunkte sichtbar machen
    //private void OnDrawGizmos()
    //{
    //    if (waypoints != null && waypoints.Length > 0)
    //    {
    //        Gizmos.color = Color.green;
    //        for (int i = 0; i < waypoints.Length; i++)
    //        {
    //            Gizmos.DrawSphere(waypoints[i].position, 0.2f);
    //            if (i < waypoints.Length - 1)
    //            {
    //                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
    //            }
    //            else
    //            {
    //                Gizmos.DrawLine(waypoints[i].position, waypoints[0].position); //Verbindung zum ersten Wegpunkt
    //            }
    //        }
    //    }
    //}
}
