using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    public FTmover player;
    public Collider2D collide;

    public AudioClip Sound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<Collider2D>();
        collide.enabled = false;
        audioSource.clip = Sound;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isFiring)
        {
            collide.enabled = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            collide.enabled = false;
            audioSource.Stop();
        }
    }
}
