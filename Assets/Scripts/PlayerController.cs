using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private float speed = 1.5f;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }
    public void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + (Vector3.right * horizontalInput * speed));
    }
}
