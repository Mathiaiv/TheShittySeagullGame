using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float minSpeed = 1f;

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
        velocity += movementInput * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    /**
    * This is the method that runs when reacieving movement input.
    *
    * @param movementInput is the movement input recived. 
    */
    void OnMove(InputValue movmentValue)
    {
        movementInput = movmentValue.Get<Vector2>();
    }
}
