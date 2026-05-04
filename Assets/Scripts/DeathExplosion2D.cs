using UnityEngine;

public class DeathExplosion2D : MonoBehaviour
{
    public float force = 5f;

    void Start()
    {
        Vector2 center = transform.position;

        Rigidbody2D[] bodies = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D rb in bodies)
        {
            Vector2 direction = (rb.position - center).normalized;
            
            // if objec tis exactly at the center
            if (direction == Vector2.zero)
                direction = Random.insideUnitCircle.normalized;

            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}