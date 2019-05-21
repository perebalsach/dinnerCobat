using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float dashForce;
    private Rigidbody rb;
    
    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        if (movement != Vector3.zero)
        {
            this.transform.forward = movement;
        }

        rb.MovePosition(rb.position + movement * velocity * Time.fixedDeltaTime);

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Dash");

            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashForce * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
            rb.AddForce(dashVelocity, ForceMode.VelocityChange);
        }


    }
}
