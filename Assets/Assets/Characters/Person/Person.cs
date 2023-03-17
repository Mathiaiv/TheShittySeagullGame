using UnityEngine;
using Pathfinding;

/// <summary>
/// A script handling the movement of a person
/// </summary>
public class Person : MonoBehaviour
{
    private Vector3 end;
    private Seeker _seeker;
    private Path _path;
    
    [SerializeField] private float timeBetweenPathCalculations = 0.5f;
    private float _time;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float finishRadius = 0.16f;
    private Animator _animator;
    private SpriteChanger _spriteChanger;
    private Vector3 _direction;
    private Vector3 _acceleration;
    private const float TurningSensitivity = 5f;
    private static readonly int DirX = Animator.StringToHash("dirX");
    private static readonly int DirY = Animator.StringToHash("dirY");
    private static readonly int IsPoopedOn = Animator.StringToHash("isPoopedOn");

    private void Awake()
    {
        _seeker = GetComponent<Seeker>();
        _animator = GetComponent<Animator>();
        _spriteChanger = GetComponent<SpriteChanger>();
        gameObject.SetActive(false);
    }

    public void Spawn(int skinNr, float speed, Vector3 start, Vector3 end)
    {
        transform.position = start;
        this.end = end;
        _seeker.StartPath(transform.position, end, OnPathComplete);
        
        _spriteChanger.skinNr = skinNr;
        gameObject.SetActive(true);
        this.speed = speed;
        _animator.SetBool(IsPoopedOn, false);
        _direction = (end - start).normalized;
    }
    
    public void OnPathComplete (Path p)
    {
        if (p.error) return;
        _path = p;
        _time = 0;
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (!enabled) return;
        if (_path == null || _path.vectorPath.Count < 1)
        {
            gameObject.SetActive(false);
            return;
        }
        if (_time > timeBetweenPathCalculations)
        {
            _seeker.StartPath(transform.position, end, OnPathComplete);
        }
        _time += Time.deltaTime;
        
        // Get direction to the next waypoint on the path
        var nextWaypoint = _path.vectorPath[0];
        _acceleration = (nextWaypoint - transform.position).normalized;

        // Update the direction with the new acceleration vector
        _direction += TurningSensitivity * Time.fixedDeltaTime * _acceleration;
        _direction.Normalize();

        // Remove waypoint from the path if we are close enough to it
        if (Vector2.Distance(transform.position, nextWaypoint) < finishRadius) 
        { 
            _path.vectorPath.RemoveAt(0); 
        }
        
        _animator.SetFloat(DirX, _direction.x);
        _animator.SetFloat(DirY, _direction.y);
        transform.position += _direction * (speed * Time.fixedDeltaTime);
        if ((Vector2.Distance(transform.position, end) > finishRadius)) return;
        gameObject.SetActive(false);
    }

    /*
     * Runs if the person has been pooped on
    */
    public void Shot()
    {
        if (_animator.GetBool(IsPoopedOn)) return;
        _animator.SetBool(IsPoopedOn, true);
        speed *= 3;
    }
}
