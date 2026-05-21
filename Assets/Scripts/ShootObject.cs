using System;
using UnityEditor;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    public float triggerDistance = 10f;
    public float force = 3f;
    
    private Rigidbody2D rb;
    private Transform player;
    private bool objectShot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (!objectShot && player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= triggerDistance)
            {
                objectShot = true;
                
                Vector2 direction = (player.position - transform.position).normalized;
                rb.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
    }
}
