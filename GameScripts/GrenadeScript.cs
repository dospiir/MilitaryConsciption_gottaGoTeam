using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float throwForce = 10f;        // The force applied to throw the grenade
    public float explosionRadius = 3f;    // The radius of the explosion
    public float explosionForce = 100f;// The force applied by the explosion
    public EnemyController enemy;
    

    private Rigidbody2D rb;
    public Transform throwPosition;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Explode();
    }

    private void Explode()
    {
        
       

        // Get all colliders within the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        if (enemy != null )
        {
            // Apply damage to the enemy
            enemy.TakeDamage(110);
        }

        // Destroy the grenade
        Destroy(gameObject);
    }
}
