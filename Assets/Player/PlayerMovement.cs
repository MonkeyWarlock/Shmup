using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float myMoveSpeed;
    public PlayerInputs myPlayerControls;

    Vector2 myMoveDirection = Vector2.zero;
    private InputAction myPlayerMove;
    private InputAction myPlayerAttack;

    public GameObject myBullet;
    private bool isShooting;

    public float myFireRate;
    private float myTimeToFire = 0.0f;

    private void Awake()
    {
        myPlayerControls = new PlayerInputs();
        isShooting = false;
    }

    private void OnEnable()
    {
        myPlayerMove = myPlayerControls.Player.Move;
        myPlayerMove.Enable();
        myPlayerAttack = myPlayerControls.Player.Attack;
        myPlayerAttack.started += ctx => Shoot();
        myPlayerAttack.canceled += ctx => NoShoot();
        myPlayerAttack.Enable();
    }

    private void OnDisable()
    {
        myPlayerMove.Disable();
        myPlayerAttack.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        myMoveDirection = myPlayerMove.ReadValue<Vector2>();

        if (isShooting && Time.time > myTimeToFire)
        {
            myTimeToFire = Time.time + myFireRate;
            CreateBullet();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(myMoveDirection.x * myMoveSpeed, myMoveDirection.y * myMoveSpeed);
    }

    private void Shoot()
    {
        isShooting = true;
    }

    private void NoShoot()
    {
        isShooting = false;
    }

    private void CreateBullet()
    {
        Instantiate(myBullet, transform.position, Quaternion.identity);
    }
}
