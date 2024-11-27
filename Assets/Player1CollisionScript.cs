using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player1CollisionScript : MonoBehaviour
{
    public Player1MovementScript movement;

    void OnCollisionEnter (Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
        if (collisionInfo.collider.tag == "Spike")
        {
            movement.enabled = false;
            FindObjectOfType<GameManagerScript>().Endgame();

        }
    }
}
