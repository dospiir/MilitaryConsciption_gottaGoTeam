using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBlast : MonoBehaviour
{
    public NadeExploder nade;
    public Animator anim;

    public AudioClip soundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
      
            
            
        
        
    }
}
