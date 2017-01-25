using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float minJumpHeight;
    private float maxJumpHeight;
    private float jumpTime;
    public float gravity;
    private float minJumpVelocity;
    private float maxJumpVelocity;
    private float velocityXMovement;
    private float airAccelerationTime;
    private float accelerationGroundTime;
    private Vector2 input;
    private Vector2 velocity;
    private bool canMove;
    private Rigidbody2D RB;

    [SerializeField]
    private GameObject healthContainer;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        speed = 3.0f;
        minJumpHeight = 0.2f;
        maxJumpHeight = 1.00f;
        jumpTime = 0.4f;
        airAccelerationTime = 0.2f;
        accelerationGroundTime = 0.1f;
        canMove = true;

        gravity = -(2.0f * maxJumpHeight) / Mathf.Pow(jumpTime, 2.0f);
        minJumpVelocity = Mathf.Sqrt(2.0f * Mathf.Abs(gravity) * minJumpHeight);
        maxJumpVelocity = Mathf.Abs(gravity) * jumpTime; 
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
           velocity = InputManager.Instance.Movement();
            RB.velocity = new Vector2(velocity.x * speed, velocity.y * speed);
        }
        if (Input.GetButtonDown("Jump"))
        {
            GameObject prefab = Instantiate(healthContainer);
            prefab.name = "Health Container";
        }
    }
    
}
