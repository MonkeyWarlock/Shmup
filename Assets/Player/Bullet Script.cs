using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletScript : MonoBehaviour
{
    public float mySpeed;
    public float myDuration;
    public float myDamage;

    private void Update()
    {
        ShootBolt();

        Destroy(gameObject, myDuration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
        }
    }

    private void ShootBolt()
    {
        Vector2 v = transform.position;
        v.x += mySpeed * Time.deltaTime;

        transform.position = v;
    }
}
