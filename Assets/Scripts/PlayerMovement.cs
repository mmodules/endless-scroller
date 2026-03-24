using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject background;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        background.transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        
        if (Keyboard.current.spaceKey.isPressed)
        {
            horizontalSpeed = 10f;
        }
        else
        {
            horizontalSpeed = 5f;
        }
        
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
    }
}
