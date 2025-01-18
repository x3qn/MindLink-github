using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallScript : MonoBehaviour
{
    [Header("Rotationseinstellungen")]
    public Transform pivotPoint; // Der Punkt, um den sich die Falle dreht
    public float rotationSpeed = 50f; // Rotationsgeschwindigkeit in Grad pro Sekunde

    void Update()
    {
        if (pivotPoint != null)
        {
            // Drehe das Objekt um den Pivot-Punkt
            transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
