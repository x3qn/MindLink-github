using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Target Portal")]
    [Tooltip("Das Zielportal, zu dem teleportiert werden soll.")]
    public Transform targetPortal;

    [Header("Spieler-Layer")]
    [Tooltip("Layer, die für Spieler verwendet werden.")]
    public LayerMask playerLayers; // Hier werden die Layer für Player1 und Player2 eingestellt.

    private void OnTriggerEnter(Collider other)
    {
        // Prüfen, ob das Objekt in einem der angegebenen Spieler-Layer ist
        if (IsInPlayerLayer(other.gameObject) && targetPortal != null)
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // Spielerposition zur Zielportalposition verschieben mit einem kleinen Versatz
        player.transform.position = targetPortal.position + targetPortal.forward * 1.5f;
        player.transform.rotation = targetPortal.rotation;
    }

    private bool IsInPlayerLayer(GameObject obj)
    {
        // Überprüft, ob das Objekt in einem der spezifizierten Layer ist
        return (playerLayers.value & (1 << obj.layer)) > 0;
    }
}
