using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level09MovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    void FixedUpdate()
    {
        transform.position += Vector3.right * moveSpeed * Time.fixedDeltaTime;
    }
}