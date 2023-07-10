using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class EnemyController : MonoBehaviour
{

    public float health = 100f;
    public int bulletDamage;
    public Animator anim;
    public bool isDead;
    public Collider2D box;

    private void Start()
    {
        isDead = false;
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
        else if (collision.gameObject.CompareTag("Blast"))
        {
            isDead = true;
            TakeDamage(110);
        }
        else if (collision.gameObject.CompareTag("Flame"))
        {
            isDead = true;
            anim.SetBool("FireDead", true);
            Destroy(gameObject, 3f);
        }
    }

    public void TakeDamage(int damage)
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
        isDead = true;
        anim.SetBool("isDead", isDead);
        Destroy(gameObject, 1.15f);
        if (box != null)
        {
            box.enabled = false;
        }
    }
}