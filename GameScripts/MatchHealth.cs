using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHealth : MonoBehaviour
{
    public float health;
    public Move player;
    // Start is called before the first frame update
    void Start()
    {
        health = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        health = player.health;
    }
}
