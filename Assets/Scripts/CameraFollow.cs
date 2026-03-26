using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = 4;

    
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(0f, player.position.y + yOffset, transform.position.z);
        }
    }
}
