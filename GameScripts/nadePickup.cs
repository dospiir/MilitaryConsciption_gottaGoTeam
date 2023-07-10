using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nadePickup : MonoBehaviour
{
    public Move player;
    public Move player2;
    public Collider2D collide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.grenadeNumber = 5;
            player2.grenadeNumber = 5;
            Destroy(gameObject);
        }
    }
}
