using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Camera mainCamera;
    public Camera mainCamera2;
    public Camera mainCamera3;
    public Camera mainCamera4;

    private void Start()
    {
        // Aktiviert Main Camera und deaktiviert die anderen
        if (mainCamera != null)
        {
            ActivateCamera(mainCamera);
            Debug.Log("Main Camera is now active.");
        }
        else
        {
            Debug.LogError("Main Camera is not assigned. Please assign it in the Inspector.");
        }
    }

    private void ActivateCamera(Camera cameraToActivate)
    {
        // Deaktiviert alle Kameras
        if (mainCamera != null) mainCamera.gameObject.SetActive(false);
        if (mainCamera2 != null) mainCamera2.gameObject.SetActive(false);
        if (mainCamera3 != null) mainCamera3.gameObject.SetActive(false);
        if (mainCamera4 != null) mainCamera4.gameObject.SetActive(false);

        // Aktiviert die gewünschte Kamera
        cameraToActivate.gameObject.SetActive(true);
    }
    public void Endgame()
    {
        Debug.Log("GameOver");
    }
}
