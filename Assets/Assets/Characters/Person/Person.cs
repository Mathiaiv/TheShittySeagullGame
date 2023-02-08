using System;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A script handling the movement of a person
/// </summary>
public class Person : MonoBehaviour
{
    public Transform start;
    public Transform end;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float finishRadius = 1f;
    private Vector3 _direction;
    private Vector3 _acceleration;
    private const float TurningSensitivity = 5f;
    [SerializeField] private float angle = 2f;
    [SerializeField] private float visionDistance = 3f;

    public void Spawn()
    {
        transform.position = start.position;
        _direction = (end.position - transform.position).normalized;
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (!enabled) return;
        var hit = Physics2D.Raycast(transform.position + _direction, end.position - transform.position, visionDistance);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position + _direction, hit.point, Color.red);
            _acceleration = Quaternion.AngleAxis(angle, Vector3.forward) * _direction;
            //hit = Physics2D.Raycast(transform.position + _direction, _direction, visionDistance);
        }
        else
        {
            _acceleration = (end.position - transform.position).normalized;
        }
        
        _direction += TurningSensitivity * Time.fixedDeltaTime * _acceleration;
        _direction.Normalize();
        transform.position += _direction * (speed * Time.fixedDeltaTime);
        
        if ((Vector2.Distance(transform.position, end.position) > finishRadius)) return;
        gameObject.SetActive(false);
    }
}
