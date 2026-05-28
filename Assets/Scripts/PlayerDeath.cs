using System;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject explosionObject;
    [SerializeField] private AudioSource[] audioSources;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            KillPlayer();
        }
        else
        {
            audioSources[0].Play();
        }
    }

    private void OnBecameInvisible()
    {
        KillPlayer();
    }

    void KillPlayer()
    {
        Score.timeBetweenIncrements = 999999f;
        mainCamera.GetComponent<CameraShake2D>().Shake(1f, 0.3f);
           
        Instantiate(explosionObject, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
            
        CameraFollow.followPlayer = false;
            
        audioSources[1].Play();

        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Game Over");
    }
}
