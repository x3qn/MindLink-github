using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatformScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private BoxCollider2D platformCollider;

    void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (player1.position.y - 1 < transform.position.y && player2.position.y - 1 < transform.position.y)
        {
            platformCollider.enabled = false;
        }
        else
        {
            platformCollider.enabled = true;
        }
    }
}