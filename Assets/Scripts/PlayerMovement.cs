using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalSpeed = 0.4f;
    public float verticalSpeed = 3f;

    private float localSpeed = 5f;
    private float timeElapsed;
    //private float lastUpdateTime;
    private float speedupInterval = 0.05f;
    private bool incrementSpeed = true;

    // Update is called once per frame
    void Update()
    {
        
        KeyboardControls();
        rb.linearVelocityY = verticalSpeed;
    }

    private void KeyboardControls()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            localSpeed = horizontalSpeed * 2;
        }
        else
        {
            localSpeed = horizontalSpeed;
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            if (incrementSpeed) {rb.linearVelocityX += Math.Clamp(-1 * localSpeed, -5, 5);}
            incrementSpeed = false;
            UpdateTime();
            return;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            if (incrementSpeed) {rb.linearVelocityX += Math.Clamp(1 * localSpeed, -5, 5);}
            incrementSpeed = false;
            UpdateTime();
            return;
        }
        
        rb.linearVelocityX = 0;
    }

    private void UpdateTime()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= speedupInterval)
        {
            timeElapsed = 0f;
            incrementSpeed = true;
        }
    }

    private void MouseControls()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue(); // Screen position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        
        rb.MovePosition(new Vector2(worldPos.x, rb.position.y + verticalSpeed * Time.fixedDeltaTime));
    }
}
