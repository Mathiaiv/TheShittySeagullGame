using UnityEngine;

/// <summary>
/// A script handling the movement of a person
/// </summary>
public class PersonMovement : MonoBehaviour
{
    public Transform start;
    public Transform end;
    [SerializeField] private float speed = 1f;

    private Vector3 _velocity;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        var startPos = start.position;
        transform.position = startPos;
        _velocity = (end.position - startPos).normalized * speed;
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (!IsInRangeOfPoint(end.position, 0.5f)) transform.position += _velocity * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Checks if this person is in range of a 2d point
    /// </summary>
    /// <param name="point"> the pont ot check against </param>
    /// <param name="range"> the range in both x and y axis from the point </param>
    /// <returns> true if the person is in range of false if not</returns>
    private bool IsInRangeOfPoint (Vector2 point, float range)
    {
        Vector2 pos = transform.position;
        return pos.x > point.x + range 
               && pos.x < point.x - range 
               && pos.y > point.y + range 
               && pos.y < point.y - range;
    }
}
