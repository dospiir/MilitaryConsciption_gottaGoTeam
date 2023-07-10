using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CrouchSwaper : MonoBehaviour
{
    
    public EnemyController enemyController;
    public GameObject object1;
    public GameObject object2;

    private bool isObject1Active = true;
    private float timer = 0f;
    private float swapDelay = 2f;

    public Vector2 detectionSize = new Vector2(2f, 2f);
    public LayerMask playerLayer;
    public Transform firePointToRay;




    private void Start()
    {
        SetActiveObject();
    }

    private void Update()
    {
        if (StartPlaying())
        {

            timer += Time.deltaTime;

            if (timer >= swapDelay && !enemyController.isDead)
            {
                timer = 0f;
                SwapObjects();
            }

            if (object2 == null)
            {
                Destroy(gameObject);
            }
        }
        }
    
    private void SwapObjects()
    {
        isObject1Active = !isObject1Active;
        SetActiveObject();
        timer = 0f;
    }

    private void SetActiveObject()
    {
        if (object1 != null && object2 != null)
        {
            object1.SetActive(isObject1Active);
            object2.SetActive(!isObject1Active);
        }
    }


    bool StartPlaying()
    {
        if (firePointToRay != null)
        {
            RaycastHit2D hit = Physics2D.BoxCast(firePointToRay.transform.position, detectionSize, 0f, Vector2.zero, 0f, playerLayer);




            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {

                return true;

            }
            else
            {
                return false;
            }
        }
        else return false;
    }
}


