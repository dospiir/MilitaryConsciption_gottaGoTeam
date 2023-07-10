using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CinemachineVirtualCamera virtualCamera;
    private bool swi;

    private void Start()
    {
        swi = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            swi = !swi;
            Switch(swi);
        }
    }





    void Switch(bool toSwitch)
    {
        if (toSwitch == true)
        {
            virtualCamera.Follow = player2.transform;
        }
        else
        {
            virtualCamera.Follow = player1.transform;
        }
    }

   
}
