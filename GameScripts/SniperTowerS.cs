using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SniperTowerS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flame"))
        {
           StartCoroutine(LoadNextSceneWithDelay());
        }
    }


    private IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(2f); // Adjust the delay duration as needed

        // Load the next scene
        SceneManager.LoadScene("Outro");
    }
}
