using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = 4;

    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, player.position.y + yOffset, transform.position.z);
    }
}
