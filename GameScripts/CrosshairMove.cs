using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMove : MonoBehaviour
{

    
    
    private Vector2 mousePos;


   
    private void Awake()
    {
        
        Cursor.visible = false;
    }



    void Update()
    {


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;

       

    }
}
