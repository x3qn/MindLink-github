using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4CameraScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private void Update()
    {
        if (player1 != null && player2 != null)
        {
            UpdateCameraPosition();
        }
        else
        {
            Debug.LogError("Player1 or Player2 is not assigned in the Inspector!");
        }
    }

    private void UpdateCameraPosition()
    {
        float player1Height = player1.transform.position.y;
        float player2Height = player2.transform.position.y;

        // Kamera auf -23 setzen, wenn beide Spieler höher als -28 sind
        if (player1Height > -27 && player2Height > -27 && transform.position.y != -23f)
        {
            MoveCameraTo(-23f);
        }

        // Kamera auf -13 setzen, wenn beide Spieler höher als -19 sind
        if (player1Height > -17 && player2Height > -17 && transform.position.y != -13f)
        {
            MoveCameraTo(-13f);
        }

        // Kamera auf -3 setzen, wenn beide Spieler höher als 1 sind
        if (player1Height > -9 && player2Height > -9 && transform.position.y != -3f)
        {
            MoveCameraTo(-3f);
        }
    }

    private void MoveCameraTo(float targetY)
    {
        Vector3 newPosition = transform.position;
        newPosition.y = targetY;
        transform.position = newPosition;

        Debug.Log($"Main Camera moved to y = {targetY}");
    }
}
