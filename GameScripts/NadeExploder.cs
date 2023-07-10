using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NadeExploder : MonoBehaviour
    {
        float timer;
        public GameObject grenade;
        public GameObject blast;
        public bool Exploded;

   

    private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            timer = 0;
        
    }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;

            if (timer > 3f)
            {

            
                Exploded = true;
                grenade.SetActive(false);
                rb.isKinematic = true;

                rb.angularDrag = 100f;
                blast.SetActive(true);
               

            Destroy(gameObject, 2f);

            }

         


        }
    }



