using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(2.439f, 0.087f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        transform.localScale = player.localScale;
    }
}
