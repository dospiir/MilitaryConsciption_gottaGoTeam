using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed;
    public float runningSpeed;
    public float crouchingSpeed;
    public float direction = 0f;
    public Rigidbody2D player;
    public float health;
    public float damage;
    public Move getOtherHealth;

    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask Ground;
    private bool isGrounded;

    public Animator anim;
    public SpriteRenderer sprite;


    bool isRunning;
    bool isJumping;
    bool isCrouching;
    bool isGunOut;
    public bool canShoot;
    bool canNade;

    public GameObject nonControl;
    public GameObject Control;
    public Transform nonCntrl;
    public Transform control;
    private GameObject activeObject;

    public CapsuleCollider2D capsuleCollider;
    public float standHitBox;
    public float crouchHitBox;
    

    public Transform corps;

    public float throwForce = 10f;        
    public float explosionRadius = 3f;
    public Transform throwPosition;
    public GameObject grenade;
    public int grenadeNumber;


    public AudioClip walkingSound;
    public AudioSource audioSource;

    public GameObject sla7;
    public bool isDead;




    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        activeObject = nonControl;
        standHitBox = capsuleCollider.size.y;
        crouchHitBox = capsuleCollider.size.y /2;
        grenadeNumber = 0;
        audioSource.clip = walkingSound;
        audioSource.loop = true;

    }
    

    // Update is called once per frame
    void Update()
     

    {
        direction = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, Ground);
        Vector2 mousePosition = Input.mousePosition;

       



        if (direction < -0.01f || mousePosition.x < Screen.width/3)
        {
            
            FlipObject(true);
        }
        else if (direction > 0.01f || mousePosition.x > Screen.width / 3)
        {
            
            FlipObject(false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        else
        {
            anim.SetBool("isFiring", false);
        }




        Walking();
        Running();
        Crouching();
        Jumping();
        GunOut();
        ThrowGrenade();

       if(Mathf.Abs(speed * direction) > 0.01 && isGrounded)
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
            
            if(health > damage && getOtherHealth.health > damage)
            {
                health -= damage;
                getOtherHealth.health -= damage;
                Destroy(collision.gameObject);
            }
            else
            {
                health = 0;
                anim.SetBool("HDead", true);
                Destroy(control.gameObject, 4f);
                Destroy(nonControl.gameObject,4f);
                if(sla7 != null)
                {
                    Destroy(sla7.gameObject);
                }
                
            }
        }



    }



    private IEnumerator DelayedLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(4);
        ;
    }
    void Shoot()
    {
        anim.SetBool("isFiring", true);
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
            
            isRunning = true;
            anim.SetFloat("Velocity", Mathf.Abs(speed * direction));
            anim.SetBool("isRunning", isRunning);
            
        }


    }
        void Walking()
        {
        player.velocity = new Vector2(direction * speed, player.velocity.y);
        isRunning = false;
        canShoot = true;
            anim.SetFloat("Velocity", Mathf.Abs(speed * direction));
            anim.SetBool("isRunning", isRunning);
        
    }

    void Jumping()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            isJumping = true;
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isGrounded", false);
            anim.SetFloat("Velocity", Mathf.Abs(speed * direction));
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            
        }
        else
        {
            isJumping = false;
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isGrounded", isGrounded);
        }
    }

    void GunOut()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {


            SwapObjects();
            isGunOut = !isGunOut;
            anim.SetBool("isGunOut", isGunOut);
            
        }
    }


       void Combat(bool isGunOut)
    {
        if (isGunOut == true)
        {
            nonControl.SetActive(false);
            Control.SetActive(true);

        }
        else if (isGunOut == false) 
        {
            nonControl.SetActive(true);
            Control.SetActive(false);
        }
    }


    private void SwapObjects()
    {
       

        // Swap the active object
        if (activeObject == nonControl)
        {
            control.position = nonCntrl.position;
            canNade = true;
            Control.SetActive(true);
            nonControl.SetActive(false) ;
        }
        else
        {
            nonCntrl.position = control.position;
            canNade = false;
            nonControl.SetActive(true);
            Control.SetActive(false);
            
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


        if (Input.GetKeyDown(KeyCode.C) && grenadeNumber != 0 && canNade)
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
            grenadeNumber = grenadeNumber - 1;

            
        }
    }



    private void OnDestroy()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("DeadLevel1");
        }
    }
}
