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

    private void Awake()
    {
        myPlayerControls = new PlayerInputs();
    }

    private void OnEnable()
    {
        myPlayerMove = myPlayerControls.Player.Move;
        myPlayerMove.Enable();
        myPlayerAttack = myPlayerControls.Player.Attack;
        myPlayerAttack.started += Shoot;
        myPlayerAttack.Enable();
    }

    private void OnDisable()
    {
        myPlayerMove.Disable();
        myPlayerAttack.canceled -= Shoot;
        myPlayerAttack.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        myMoveDirection = myPlayerMove.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(myMoveDirection.x * myMoveSpeed, myMoveDirection.y * myMoveSpeed);
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Instantiate(myBullet, transform.position, Quaternion.identity);
    }
}
