using UnityEngine;

public class WindZoneSwitchScript : MonoBehaviour
{
    public GameObject[] windZones; // Array für die WindZones
    public Animator switchAnimator; // Referenz zum Animator
    public float cooldownTime = 1f; // Cooldown-Zeit in Sekunden

    private int activeIndex = -1; // Speichert die aktuell aktive WindZone (-1 bedeutet keine aktiv)
    private bool canToggle = true; // Cooldown-Steuerung
    private bool isSwitchOn = false; // Steuert die Animation (wechselt zwischen an/aus)

    // Start wird beim Spielstart aufgerufen
    private void Start()
    {
        // Automatisch einmal die WindZone umschalten
        ToggleWindZone();
    }

    private void ToggleWindZone()
    {
        if (!canToggle) return; // Falls Cooldown aktiv, nichts tun

        // Deaktiviere die aktuell aktive WindZone
        if (activeIndex >= 0)
        {
            windZones[activeIndex].SetActive(false);
        }

        // Aktiviere die nächste WindZone (zyklisch wechseln)
        activeIndex = (activeIndex + 1) % windZones.Length;
        windZones[activeIndex].SetActive(true);

        // Switch-Animation wechseln
        isSwitchOn = !isSwitchOn;
        if (switchAnimator != null)
        {
            switchAnimator.SetBool("Switch_On", isSwitchOn);
        }

        // Cooldown starten
        canToggle = false;
        Invoke(nameof(ResetCooldown), cooldownTime);
    }

    private void ResetCooldown()
    {
        canToggle = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2")) // Prüfen, ob der Spieler den Schalter berührt
        {
            ToggleWindZone();
        }
    }
}
