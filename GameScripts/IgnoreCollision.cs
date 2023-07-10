using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public Collider2D collider1;
    public Collider2D collider2;

    private void Start()
    {
        // Ignore collisions between collider1 and collider2
        Physics2D.IgnoreCollision(collider1, collider2);
    }
}
