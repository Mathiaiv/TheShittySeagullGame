using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = start.position;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
