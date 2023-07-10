using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Player")) {

            Destroy(gameObject);
        
        }
    }
}
