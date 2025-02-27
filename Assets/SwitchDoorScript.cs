using UnityEngine;

public class SwitchDoorScript : MonoBehaviour
{
    public GameObject targetObject; // Das Objekt, das aktiviert oder deaktiviert werden soll
    public Animator switchAnimator; // Animator für die Schalteranimation
    public float cooldownTime = 1f; // Cooldown-Zeit in Sekunden

    private bool isObjectActive = false; // Speichert den aktuellen Zustand des Objekts
    private bool canToggle = true; // Kontrolliert, ob der Schalter gerade aktivierbar ist

    private void Start()
    {
        // Schalter beim Spielstart einmal aktivieren
        ToggleObject();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player1") || other.CompareTag("Player2")) && canToggle)
        {
            ToggleObject();
        }
    }

    private void ToggleObject()
    {
        if (!canToggle) return; // Falls Cooldown aktiv, nichts tun

        isObjectActive = !isObjectActive; // Zustand umkehren

        // Aktiviert oder deaktiviert das Zielobjekt
        if (targetObject != null)
        {
            targetObject.SetActive(isObjectActive);
        }

        // Animation umschalten, wenn Animator vorhanden ist
        if (switchAnimator != null)
        {
            switchAnimator.SetBool("Switch_On", isObjectActive);
        }

        // Cooldown starten
        canToggle = false;
        Invoke(nameof(ResetCooldown), cooldownTime);
    }

    private void ResetCooldown()
    {
        canToggle = true; // Cooldown zurücksetzen
    }
}
