using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction;
    public float sensitivity;

    Vector2 movementInput;
    Rigidbody2D rb;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        direction += movementInput * sensitivity * Time.fixedDeltaTime;
        direction.Normalize();
        velocity = speed * direction;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    /**
    * This is the method that runs when recieving movement input.
    *
    * @param movementInput is the movement input recived. 
    */
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
