using System;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = 4;
    
    public static bool followPlayer = true;

    void Start()
    {
        followPlayer = true;
    }
   
    void Update()
    {
        if (followPlayer)
        {
            Debug.Log(transform.position);
            transform.position = new Vector3(0f, player.position.y + yOffset, transform.position.z);
        }
    }
}
