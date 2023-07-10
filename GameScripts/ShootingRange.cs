using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public EnemyShootingScript enemy;
    float time;

    public Vector2 detectionSize = new Vector2(2f, 2f);
    public LayerMask playerLayer;
    public Transform firePointToRay;

    public bool start;
    public bool PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnDrawGizmosSelected()
    {

        // Draw the boxcast borders
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(firePointToRay.transform.position , detectionSize);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        
        RaycastHit2D hit = Physics2D.BoxCast(firePointToRay.transform.position, detectionSize, 0f, Vector2.zero, 0f, playerLayer);

        
        
        
            if (hit.collider != null && hit.collider.CompareTag("Player") && !enemy.isDed)
            {
            PlayerMove = false;
                   
                    if (time > 2)
                    {
                        time = 0;
                        enemy.EnemyShoot();
                    }
                
            }
            else
        {
            PlayerMove = true;
        }
            
        
    }

   
}
