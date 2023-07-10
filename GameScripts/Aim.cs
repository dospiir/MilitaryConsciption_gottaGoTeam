using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

   
    private Vector3 mousePos;
    public float sens;
    public Move scale;
    

    
   

    



    void Update()
    {
       
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       


        if (scale.nonControl.transform.localScale.x > 0f)
        {
            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            rotZ = Mathf.Clamp(rotZ, 0f, 40f);

            transform.rotation = Quaternion.Euler(0, 0, rotZ * sens);

        }
        else
        {
            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            rotZ = Mathf.Clamp(rotZ, 0f, -40f);

            transform.rotation = Quaternion.Euler(0, 0, rotZ * sens);
        }
    }
}
