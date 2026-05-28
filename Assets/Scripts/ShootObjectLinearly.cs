using UnityEngine;

public class ShootObjectLinearly : MonoBehaviour
{
    public float triggerDistance = 10f;
    public float force = 3f;
    
    private Rigidbody2D rb;
    private Transform player;
    private bool objectShot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (!objectShot && player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= triggerDistance)
            {
                objectShot = true;
                force = Random.Range(force*0.9f, force*1.1f);
                rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
            }
        }
    }
}
