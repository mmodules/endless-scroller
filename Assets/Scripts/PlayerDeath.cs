using System;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject explosionObject;
    public GameObject scoreObject;
    [SerializeField] private AudioSource[] audioSources;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            scoreObject.GetComponent<Score>().timeBetweenIncrements = 200f;
            mainCamera.GetComponent<CameraShake2D>().Shake(1f, 0.3f);
           
            Instantiate(explosionObject, transform.position, transform.rotation);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            
            audioSources[1].Play();

            StartCoroutine(Wait());
        }
        else
        {
            audioSources[0].Play();
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Game Over");
    }
}
