using UnityEngine;

public class SwitchDoorScript : MonoBehaviour
{
    public GameObject targetObject; // Das Objekt, das aktiviert oder deaktiviert werden soll

    private bool isObjectActive = false; // Speichert den aktuellen Zustand des Objekts

    // Methode, die ausgel�st wird, wenn der Spieler den Schalter betritt
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1")) // Pr�ft, ob der Spieler den Schalter ber�hrt
        {
            ToggleObject(); // Schaltet das Zielobjekt um
        }
    }

    // Umschalten des Zielobjekts (aktivieren/deaktivieren)
    private void ToggleObject()
    {
        isObjectActive = !isObjectActive; // Umkehren des aktuellen Zustands

        // Aktiviert oder deaktiviert das Zielobjekt
        if (targetObject != null)
        {
            targetObject.SetActive(isObjectActive);
        }
    }
}
