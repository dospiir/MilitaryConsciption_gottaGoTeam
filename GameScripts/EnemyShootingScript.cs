using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class EnemyShootingScript : MonoBehaviour
{

    public float health = 100f;
    public int bulletDamage;

    public Transform player;
    public GameObject projectilePrefab;
    public Transform EnemyfirePoint;
    public ShootingRange range;
    public Animator anim;
    private Rigidbody2D rb;
    public bool isDed;

    public AudioClip enemyShot;
    public AudioSource audioSource;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }



     void Update()
    {
        
        if (range.PlayerMove == true && gameObject.CompareTag("walkingShooter"))
        {
                
                rb.velocity = -Vector2.right;
            }
                 
        
        else { rb.velocity = Vector2.zero;
            anim.SetBool("playerInRange", true); 
        }

        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Handle the collision with the projectile
            TakeDamage(bulletDamage);
            Destroy(collision.gameObject);


            // Add any other actions or logic you want to perform when the enemy is hit
        }

        
    }


   

    void TakeDamage(int damage)
    {
        if (damage < health)
        {

            health -= damage;

        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        isDed = true;
        Destroy(gameObject, 2f);
    }

    public void EnemyShoot()
    {
        Instantiate(projectilePrefab, EnemyfirePoint.position, Quaternion.identity);
        audioSource.clip = enemyShot;
        audioSource.Play();
    }
}
