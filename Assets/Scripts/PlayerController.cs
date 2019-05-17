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

        if(Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += transform.forward * velocity;
        }
        if(Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position += -transform.forward * velocity;
        }

        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotationSpeed, Space.World);
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed, Space.World);
        }
    }
}
