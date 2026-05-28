using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private float verticalSpeed = 4f;

    private Camera cam;

    private bool dragging = false;

    private Vector3 previousMouseWorldPos;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleMouseInput();
    }

    void FixedUpdate()
    {
        float horizontalVelocity = 0f;

        if (dragging)
        {
            Vector3 currentMouseWorldPos = GetMouseWorldPosition();
            float deltaX = currentMouseWorldPos.x - previousMouseWorldPos.x;
            
            horizontalVelocity = deltaX / Time.fixedDeltaTime;
            previousMouseWorldPos = currentMouseWorldPos;
        }

        // Apply movement
        rb.linearVelocity = new Vector2(horizontalVelocity, verticalSpeed);
    }

    void HandleMouseInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            dragging = true;
            previousMouseWorldPos = GetMouseWorldPosition();
        }
        
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();

        mouseScreenPos.z = -cam.transform.position.z;
        Vector3 worldPos = cam.ScreenToWorldPoint(mouseScreenPos);
        worldPos.z = 0f;

        return worldPos;
    }
}