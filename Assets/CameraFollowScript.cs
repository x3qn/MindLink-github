using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform player; // Referenz auf das Spieler-Transform
    public float offsetX = 5f; // Abstand der Kamera auf der X-Achse
    public float fixedY = 0f; // Feste Y-Position der Kamera

    void Update()
    {
        if (player != null)
        {
            // Aktualisiere die Position der Kamera basierend auf der Spielerposition
            transform.position = new Vector3(player.position.x + offsetX, fixedY, transform.position.z);
        }
    }
}