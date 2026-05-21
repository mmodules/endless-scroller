using System;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 20f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation + rotationSpeed * Time.fixedDeltaTime);
    }
}
