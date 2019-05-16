using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;

    private Rigidbody rb;
    
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        
        
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        Debug.Log(movement);
        rb.velocity = movement * vertical;
        
    }
}
