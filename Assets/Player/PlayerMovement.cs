using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float myMoveSpeed;
    public PlayerInputActions myPlayerControls;

    Vector2 myMoveDirection = Vector2.zero;
    private InputAction myPlayerMove;
    private InputAction myPlayerAttack;

    private void Awake()
    {
        myPlayerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        myPlayerMove = myPlayerControls.Player.Move;
        myPlayerMove.Enable();
    }

    private void OnDisable()
    {
        myPlayerMove.Disable();
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
}
