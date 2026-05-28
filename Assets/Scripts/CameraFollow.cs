using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = 4;
    
    [SerializeField] private float scrollSpeed = 4f;
    
    public static bool followPlayer = true;

    void Start()
    {
        followPlayer = true;
    }
   
    void LateUpdate()
    {
        if (followPlayer)
        {
            transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
        }
    }
}
