using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Target Portal")]
    [Tooltip("Das Zielportal, zu dem teleportiert werden soll.")]
    public Transform targetPortal;

    [Header("Teleport Einstellungen")]
    [Tooltip("Abkühlzeit, um mehrfaches Teleportieren zu vermeiden.")]
    public float teleportCooldown = 1.0f;

    [Header("Spieler-Layer")]
    [Tooltip("Layer, die für Spieler verwendet werden.")]
    public LayerMask playerLayers; // Hier werden die Layer für Player1 und Player2 eingestellt.

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        // Prüfen, ob das Objekt in einem der angegebenen Spieler-Layer ist
        if (IsInPlayerLayer(other.gameObject) && canTeleport && targetPortal != null)
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // Spielerposition zur Zielportalposition verschieben mit einem kleinen Versatz
        player.transform.position = targetPortal.position + targetPortal.forward * 1.5f;
        player.transform.rotation = targetPortal.rotation;

        // Teleport-Sperre aktivieren
        canTeleport = false;
        targetPortal.GetComponent<Portal>().DisableTeleportForCooldown();

        // Abkühlzeit starten
        Invoke(nameof(ResetTeleport), teleportCooldown);
    }

    private void ResetTeleport()
    {
        canTeleport = true;
    }

    public void DisableTeleportForCooldown()
    {
        canTeleport = false;
        Invoke(nameof(ResetTeleport), teleportCooldown);
    }

    private bool IsInPlayerLayer(GameObject obj)
    {
        // Überprüft, ob das Objekt in einem der spezifizierten Layer ist
        return (playerLayers.value & (1 << obj.layer)) > 0;
    }
}