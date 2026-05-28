using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float verticalSpeed = 4f;
    private float homeOffsetY = -2f;
    private float catchUpForce = 8f;
    
    private Camera cam;
    private Transform cameraTransform;

    private bool dragging = false;

    private Vector3 previousMouseWorldPos;

    void Start()
    {
        cam = Camera.main;
        cameraTransform = cam.transform;
        rb = GetComponent<Rigidbody2D>();
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
            
            horizontalVelocity = Mathf.Clamp(deltaX / Time.fixedDeltaTime, -50f, 50f);
            previousMouseWorldPos = currentMouseWorldPos;
        }
        
        // home position
        float targetY = cameraTransform.position.y + homeOffsetY;

        float distanceBehind = targetY - rb.position.y;

        // move up
        float verticalVelocity = verticalSpeed;

        // rubber-band upwards if falling behind
        if (distanceBehind > 0f)
        {
            verticalVelocity += distanceBehind * catchUpForce;
        }

        rb.linearVelocity = new Vector2(horizontalVelocity, verticalVelocity);
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