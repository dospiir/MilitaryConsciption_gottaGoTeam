using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RsasaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")|| collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (collision.gameObject.CompareTag("EnemyBullet"))
            {

                Destroy(gameObject);
                Destroy(collision.gameObject);

            }
            else
            {
                Destroy(gameObject) ;
            }

            // Add any other actions or logic you want to perform when the enemy is hit
        }
    }
}
