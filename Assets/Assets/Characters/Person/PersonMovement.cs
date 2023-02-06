using UnityEngine;

/// <summary>
/// A script handling the movement of a person
/// </summary>
public class PersonMovement : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public bool isFinished;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float finishRadius = 1f;
    private Vector3 _velocity;
    
    public void Spawn()
    {
        transform.position = start.position;
        UpdateVelocity();
        isFinished = false;
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (isFinished) return;
        if (Vector3.Distance(transform.position, end.position) < finishRadius) 
        {
            isFinished = true;
            return;
        }
        UpdateVelocity();
        transform.position += _velocity * Time.fixedDeltaTime;
    }

    private void UpdateVelocity()
    {
        _velocity = (end.position - transform.position).normalized * speed;
        transform.up = _velocity;
    }
}
