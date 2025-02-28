using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform player1; //Transform von Player1
    public Transform player2; //Transform von Player2
    public float chaseSpeed = 3.5f;//Geschwindigkeit des Gegners
    public float stoppingDistance = 1.5f;//Distanz, bei der der Gegner stoppt

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        //NavMeshAgent initialisieren
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent-Komponente nicht gefunden!");
        }
        else
        {
            navMeshAgent.speed = chaseSpeed;
            navMeshAgent.stoppingDistance = stoppingDistance;
        }
    }

    void Update()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player1 oder Player2 ist nicht zugewiesen!");
            return;
        }

        //Abstand zu beiden Spielern berechnen
        float distanceToPlayer1 = Vector3.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector3.Distance(transform.position, player2.position);

        //Ziel basierend auf dem näheren Spieler setzen
        Transform target = distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;

        //Zielposition auf den NavMeshAgent setzen
        navMeshAgent.SetDestination(target.position);
    }
}

