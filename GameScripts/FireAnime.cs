using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnime : MonoBehaviour
{

    public Animator anime;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anime.SetBool("fire", true);
        }
        else
        {
            anime.SetBool("fire", false);
        }
    }
}
