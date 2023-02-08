using System;
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
    private Vector3 _velocity;

    public void Spawn()
    {
        transform.position = start.position;
        UpdateVelocity();
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (!enabled) return;
        UpdateVelocity();
        transform.position += _velocity * Time.fixedDeltaTime;
        if (Vector3.Distance(transform.position, end.position) < finishRadius) 
        {
            gameObject.SetActive(false);
            return;
        }
    }

    private void UpdateVelocity()
    {
        _velocity = (end.position - transform.position).normalized * speed;
        transform.up = _velocity;
    }
}
