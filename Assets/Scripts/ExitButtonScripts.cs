using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    //Wenn Exit-Button geklickt wird
    public void ExitGame()
    {
        //Waehrend des Debuggens in der Editor-Umgebung
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //Schließt Anwendung, wenn sie gebaut und ausgeführt wird
        Application.Quit();
#endif
        Debug.Log("Spiel beendet.");
    }
}
