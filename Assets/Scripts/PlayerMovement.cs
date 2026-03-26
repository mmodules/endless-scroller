using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject background;
    public Rigidbody2D rb;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0, verticalSpeed * Time.deltaTime);
        
        if (Keyboard.current.spaceKey.isPressed)
        {
            horizontalSpeed = 10f;
        }
        else
        {
            horizontalSpeed = 5f;
        }
        
        Vector2 velocity = rb.linearVelocity;
        
        if (Keyboard.current.aKey.isPressed)
        {
            //transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
            velocity.x = -1 * horizontalSpeed;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            //transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
            velocity.x = 1 * horizontalSpeed;
        }
        
        
        
        velocity.y = verticalSpeed;
        rb.linearVelocity = velocity;
    }
}
