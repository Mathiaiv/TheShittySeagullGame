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
    private SpriteChanger _spriteChanger;
    private Vector3 _direction;
    private Vector3 _acceleration;
    private const float TurningSensitivity = 5f;
    private static readonly int DirX = Animator.StringToHash("dirX");
    private static readonly int DirY = Animator.StringToHash("dirY");
    private static readonly int IsPoopedOn = Animator.StringToHash("isPoopedOn");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteChanger = GetComponent<SpriteChanger>();
        gameObject.SetActive(false);
    }

    public void Spawn(int skinNr, float speed, Vector3 start, Vector3 end)
    {
        transform.position = start;
        _spriteChanger.skinNr = skinNr;
        gameObject.SetActive(true);
        this.speed = speed;
        _animator.SetBool(IsPoopedOn, false);
        this.end = end;
        _direction = (end - start).normalized;
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (!enabled) return;
        _acceleration = (end - transform.position).normalized;
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
        if (_animator.GetBool(IsPoopedOn)) return;
        _animator.SetBool(IsPoopedOn, true);
        speed *= 3;
    }
}
