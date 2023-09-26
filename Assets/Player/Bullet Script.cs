using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float myBulletSpeed;
    public float myBulletDuration;

    private void Update()
    {
        ShootBolt();

        Destroy(gameObject, myBulletDuration);
    }

    private void ShootBolt()
    {
        Vector2 v = transform.position;
        v.x += transform.forward.x * myBulletSpeed ;

        transform.translate(v, transform.rotation);
    }
}
