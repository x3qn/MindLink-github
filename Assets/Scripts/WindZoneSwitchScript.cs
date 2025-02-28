using UnityEngine;

public class WindZoneSwitchScript : MonoBehaviour
{
    public GameObject[] windZones; 
    public Animator switchAnimator;
    public float cooldownTime = 1f;

    private int activeIndex = -1; 
    private bool canToggle = true;
    private bool isSwitchOn = false;

    private void Start()
    {
        //Automatisch einmal die WindZone umschalten
        ToggleWindZone();
    }

    private void ToggleWindZone()
    {
        if (!canToggle) return; //Falls Cooldown aktiv, nichts tun

        //Deaktiviere die aktuell aktive WindZone
        if (activeIndex >= 0)
        {
            windZones[activeIndex].SetActive(false);
        }

        //Aktiviere die naechste WindZone
        activeIndex = (activeIndex + 1) % windZones.Length;
        windZones[activeIndex].SetActive(true);

        //Switch-Animation wechseln
        isSwitchOn = !isSwitchOn;
        if (switchAnimator != null)
        {
            switchAnimator.SetBool("Switch_On", isSwitchOn);
        }

        //Cooldown starten
        canToggle = false;
        Invoke(nameof(ResetCooldown), cooldownTime);
    }

    private void ResetCooldown()
    {
        canToggle = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ueberprüfen, ob Collider "Player1" oder "Player2" ist
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            ToggleWindZone();
        }
    }
}