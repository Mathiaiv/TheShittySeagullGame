using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A script handling the movement of a person
/// </summary>
public class Person : MonoBehaviour
{
    private Vector3 end;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float finishRadius = 0.16f;
    private Animator _animator;
    private Vector3 _direction;
    private Vector3 _acceleration;
    private const float TurningSensitivity = 5f;
    [SerializeField] private float angle = 5f;
    [SerializeField] private float visionDistance = 3f;
    private static readonly int DirX = Animator.StringToHash("dirX");
    private static readonly int DirY = Animator.StringToHash("dirY");
    private bool isPoopedOn;

    public void Spawn(float speed, Vector2 start, Vector2 end)
    {
        this.speed = speed;
        isPoopedOn = false;
        _animator = GetComponent<Animator>();
        transform.position = start;
        this.end = end;
        _direction = (end - start).normalized;
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (!enabled) return;
        var hit = Physics2D.Raycast(transform.position + _direction, end - transform.position, visionDistance);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position + _direction, hit.point, Color.red);
            _acceleration = Quaternion.AngleAxis(angle, Vector3.forward) * _direction;
            //hit = Physics2D.Raycast(transform.position + _direction, _direction, visionDistance);
        }
        else
        {
            _acceleration = (end - transform.position).normalized;
        }
        
        _direction += TurningSensitivity * Time.fixedDeltaTime * _acceleration;
        _direction.Normalize();
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
        if (isPoopedOn) return;
        isPoopedOn = true;
        speed *= 3;
    }
}
