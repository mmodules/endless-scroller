using System;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject explosionObject;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            mainCamera.GetComponent<CameraShake2D>().Shake(1f, 0.6f);
           
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
