using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
