using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Made by Haley Vlahos
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public int playerNum;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private string axisName;
    private string turnAxis;
    private Rigidbody rb;
    private float moveInputValue;
    private float turnInputValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Sets the player's controls
    private void Start()
    {
        axisName = "Vertical" + playerNum;
        turnAxis = "Horizontal" + playerNum;
    }

    // Makes sure it isn't moving atm, but can be affected by physics when enabled
    private void OnEnable()
    {
        rb.isKinematic = false;
        moveInputValue = 0f;
        turnInputValue = 0f;
    }

    // Makes sure it doesn't move if disabled
    private void OnDisable()
    {
        rb.isKinematic = true;
    }

    // Store the player's input and make sure the audio for the engine is playing
    private void Update()
    {
        moveInputValue = Input.GetAxis(axisName);
        turnInputValue = Input.GetAxis(turnAxis);
    }

    // Move and turn the player
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    // Adjust the position of the player based on the input
    private void Move()
    {
        Vector3 movement = transform.forward * moveInputValue * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // Adjust the rotation of the player based on the input
    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // The beans kept turning when you stopped pressing the button, if statement helps stops that
        if(Mathf.Abs(turnInputValue) > 0.1f) {
            rb.MoveRotation(rb.rotation * turnRotation);
        }
        
    }

}
