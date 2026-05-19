using System;
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
            Debug.Log(transform.position);
            transform.position = new Vector3(0f, player.position.y + yOffset, transform.position.z);
        }
    }
}
