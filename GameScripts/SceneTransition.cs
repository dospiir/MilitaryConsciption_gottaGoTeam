using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
  
    public string sceneName; // Name of the scene to load

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Change the tag according to your player object's tag
        {
            SceneManager.LoadScene("ADONJON"); // Load the specified scene
        }
    }
}

