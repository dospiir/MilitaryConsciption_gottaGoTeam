using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FTmover : MonoBehaviour
{
    public float speed;
    public float runningSpeed;
    public float crouchingSpeed;
    public float direction = 0f;
    public Rigidbody2D player;
    public float health;
    public float damage;
   

    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask Ground;
    private bool isGrounded;

    public Animator anim;
    public Animator anim1;
    public SpriteRenderer sprite;


    
    bool isCrouching;
    bool isGunOut;
    public bool canShoot;

 

    public CapsuleCollider2D capsuleCollider;
    public float standHitBox;
    public float crouchHitBox;


    public Transform corps;

    public float throwForce = 10f;
    public float explosionRadius = 3f;
    public Transform throwPosition;
    public GameObject grenade;

    public bool isFiring;

    public AudioClip walkingSound;
    public AudioSource audioSource;

    public bool HDead;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
      
        standHitBox = capsuleCollider.size.y;
        crouchHitBox = capsuleCollider.size.y / 2;

        audioSource.clip = walkingSound;
        audioSource.loop = true;
    }


    // Update is called once per frame
    void Update()


    {
        direction = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Ground);
        Vector2 mousePosition = Input.mousePosition;





        if (direction < -0.01f || mousePosition.x < Screen.width / 3)
        {

            FlipObject(true);
        }
        else if (direction > 0.01f || mousePosition.x > Screen.width / 3)
        {

            FlipObject(false);
        }

        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            Shoot();
        }
        else
        {
            isFiring = false;
            anim1.SetBool("isFiring", false);
            
            
        }


      



        Walking();
        Running();
        Crouching();
        Jumping();
        
        ThrowGrenade();


        if (Mathf.Abs(speed * direction) > 0.01 && isGrounded)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }




    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {

            if (health > damage)
            {
                health -= damage;
               
                Destroy(collision.gameObject);
            }
            else
            {
                health = 0;
                anim.SetBool("HDead", true);
                Destroy(gameObject, 4f);
                
            }
        }



    }




    void Shoot()
    {
        isFiring = true;
        anim1.SetBool("isFiring", true);
    }





    void OnDestroy()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("DeadLevel2");
        }
    }











    void Crouching()
    {
        if (Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            player.velocity = new Vector2(direction * crouchingSpeed, player.velocity.y);
            isCrouching = true;
            canShoot = false;
            anim.SetBool("isCrouch", isCrouching);
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, crouchHitBox);

        }
        else
        {
            isCrouching = false;
            canShoot = true;
            anim.SetBool("isCrouch", isCrouching);
            capsuleCollider.size = new Vector2(capsuleCollider.size.x, standHitBox);
        }
    }

    void Running()
    {

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && !isGunOut)
        {
            player.velocity = new Vector2(direction * runningSpeed, player.velocity.y);

            anim.SetFloat("Velocity", Mathf.Abs(speed * direction));
            
        }


    }
    void Walking()
    {
        player.velocity = new Vector2(direction * speed, player.velocity.y);
        
        canShoot = false;
        anim.SetFloat("Velocity", Mathf.Abs(speed * direction));
       
    }

    void Jumping()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
          
            
            
            anim.SetFloat("Velocity", Mathf.Abs(speed * direction));
            player.velocity = new Vector2(player.velocity.x, jumpForce);

        }
        
    }



  


 

    private void FlipObject(bool invertScale)
    {
        Vector3 newScale = corps.localScale;
        newScale.x = invertScale ? -Mathf.Abs(newScale.x) : Mathf.Abs(newScale.x);
        corps.localScale = newScale;
    }


    private void ThrowGrenade()
    {


        if (Input.GetKeyDown(KeyCode.C))
        {
            // Get the mouse position in world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction from the throw position to the mouse position
            Vector2 throwDirection = mousePosition - (Vector2)throwPosition.position;

            // Calculate the throw angle in degrees
            float throwAngle = Mathf.Atan2(throwDirection.y, throwDirection.x) * Mathf.Rad2Deg;

            GameObject grenadeInstance = Instantiate(grenade.gameObject, throwPosition.position, Quaternion.identity);

            // Calculate the velocity based on the throw angle
            Vector2 throwVelocity = Quaternion.Euler(0f, 0f, throwAngle) * Vector2.right * throwForce;

            // Apply the velocity to the grenade's Rigidbody2D
            Rigidbody2D grenadeRb = grenadeInstance.GetComponent<Rigidbody2D>();
            grenadeRb.velocity = throwVelocity;


        }
    }

}
