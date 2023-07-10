using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2 (0, 0.5f);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position + offset;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
