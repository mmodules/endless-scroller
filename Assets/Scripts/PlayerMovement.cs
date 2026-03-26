using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = 0;
        
        if (Keyboard.current.spaceKey.isPressed)
        {
            horizontalSpeed = 10f;
        }
        else
        {
            horizontalSpeed = 5f;
        }
        
        MouseControls();
        rb.linearVelocityY = verticalSpeed;
    }

    private void KeyboardControls()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            //transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
            rb.linearVelocityX = -1 * horizontalSpeed;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            //transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
            rb.linearVelocityX = 1 * horizontalSpeed;
        }
    }

    private void MouseControls()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue(); // Screen position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        
        rb.MovePosition(new Vector2(worldPos.x, rb.position.y + verticalSpeed * Time.fixedDeltaTime));
    }
}
