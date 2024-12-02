using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WalkingBlockScript : BlockScript
{
    public float walkingSpeed = 0.1f;

    new void OnCollisionEnter2D(Collision2D collision)
    {
        string temp = collision.collider.gameObject.tag;
        if (temp == "Block" || temp == "Wall")
        {
            walkingSpeed *= -1;
        }
        else
        {
            base.OnCollisionEnter2D(collision);           
        }
    }

    void FixedUpdate()
    {
        var pos = transform.position;
        pos.x = pos.x + walkingSpeed;
        transform.position = pos;
    }
}
