using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player1AnimationControllerScript : StateMachineBehaviour
{
    //private Animator animator;

    //// Bewegungsgeschwindigkeit
    //public float moveSpeed = 5f;

    //// Referenz zum Rigidbody2D für die Bewegung
    //private Rigidbody2D rb;

    //void Start()
    //{
    //    // Animator und Rigidbody initialisieren
    //    animator = GetComponent<Animator>();
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    // Spielerinput abfragen
    //    float moveInput = Input.GetAxisRaw("Horizontal");

    //    // Bewegung setzen
    //    rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    //    // Zustand für die Animation setzen
    //    if (moveInput != 0)
    //    {
    //        animator.SetBool("isRunning", true); // Wechsel zu Run
    //    }
    //    else
    //    {
    //        animator.SetBool("isRunning", false); // Wechsel zu Idle
    //    }

    //    // Spieler umdrehen, je nach Bewegungsrichtung
    //    if (moveInput > 0)
    //        transform.localScale = new Vector3(1, 1, 1); // Blick nach rechts
    //    else if (moveInput < 0)
    //        transform.localScale = new Vector3(-1, 1, 1); // Blick nach links
    //}
}
