using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRockScript : MonoBehaviour
{
    public float myHealth;

    private void Update()
    {
        if (myHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            myHealth -= 1;
        }
    }
}
