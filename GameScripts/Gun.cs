using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Move scale;
    public GameObject projectilePrefab;    
    public Transform firePoint;
    public GameObject projectile;
    private float projectileSpeed = 10f;
    public SpriteRenderer yedih;

    public string[] tagsToIgnore;

    public AudioClip soundClip;
    private AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(scale.canShoot)
        {
            yedih.enabled = true;
        }
        else
        {
            yedih.enabled = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && scale.canShoot)
        {
            Shoot();
        }
        
    }

   

    private void Shoot()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - (Vector2)firePoint.position;
        aimDirection.Normalize();

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
       
        // Reverse the aim direction if the player is flipped horizontally
        if (scale.transform.localScale.x > 0f)
        {
            float clampedAngle = Mathf.Clamp(aimAngle, -10, 50);
            aimDirection = Quaternion.Euler(0f, 0f, clampedAngle) * Vector2.right; 
        }
        else if (scale.transform.localScale.x < 0f)
        {
            float clampedAngle = Mathf.Clamp(aimAngle, 0, -40);
            aimDirection = Quaternion.Euler(0f, 0f, clampedAngle) * -Vector2.right;
        }

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Set the velocity of the projectile towards the aim direction
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = aimDirection * projectileSpeed;


        audioSource.clip = soundClip;
        audioSource.Play();


    }
}
