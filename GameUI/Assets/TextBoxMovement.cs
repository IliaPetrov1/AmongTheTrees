using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 5000f;
    }

    private void FixedUpdate()
    {
             
    }
}
