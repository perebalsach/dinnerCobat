using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float rotationSpeed;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        _rb.velocity = movement * velocity;

        if(Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(0, (60 * Time.deltaTime), 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(0, -(rotationSpeed * Time.deltaTime), 0);
        }
        
    }
}
