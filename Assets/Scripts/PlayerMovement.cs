using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
