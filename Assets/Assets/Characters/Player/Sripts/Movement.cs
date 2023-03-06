using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A script for everything to do with movement of the seagull
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float sensitivity;
    [SerializeField] private Vector2 direction;

    private Vector2 _movementInput;
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    private Vector2 _resistance;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Changes the direction of the seagull based on the sensitivity and the movement input
    /// Changes the velocity based on the speed and the direction
    /// Moves the seagull based on the velocity
    /// </summary>
    private void FixedUpdate()
    {
        //_resistance = new Vector2(0, 0);
        direction += sensitivity * Time.fixedDeltaTime * _movementInput;
        direction.Normalize();
        _rb.transform.up = direction;
        _velocity = speed * direction;
        _velocity += _resistance;
        _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
    }
    
    /// <summary>
    /// Take in the movement as a vector
    /// </summary>
    /// <param name="movementValue">
    /// is the movement input received. 
    /// </param>
    private void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    //Reset resistance here

    public void changeResistance(){

        Debug.Log("Holy Moly");
    }
}
