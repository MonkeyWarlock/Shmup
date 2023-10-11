using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletScript : MonoBehaviour
{
    public float mySpeed;
    public float myDuration;
    public float myDamage;

    private Coroutine _returnToPoolTimerCorutine;


    private void OnEnable()
    {
        _returnToPoolTimerCorutine = StartCoroutine(ReturnToPoolAfterTime());
    }


    private void FixedUpdate()
    {
        ShootBolt();
    }

    //On collision deactivate bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            //Destroy(gameObject);
            ObjectPool.ReturnObjectToPool(gameObject);
        }
    }

    private void ShootBolt()
    {
        Vector2 v = transform.position;
        v.x += mySpeed * Time.deltaTime;

        transform.position = v;
    }

    //return the bullet to the pool
    private IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < myDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPool.ReturnObjectToPool(gameObject);
    }
}
