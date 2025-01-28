using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level09MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit des Spielers

    void FixedUpdate()
    {
        // Spieler bewegt sich konstant nach rechts durch direkte Positionsänderung
        transform.position += Vector3.right * moveSpeed * Time.fixedDeltaTime;
    }
}