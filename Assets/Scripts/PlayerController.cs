using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float tolerancia;

    private Rigidbody _rb;
    private Animator _animator;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();
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
        
        _rb.velocity = new Vector3(movement.x, movement.y, movement.z) * velocity;


        if (Mathf.Abs(_rb.velocity.x) > tolerancia || Mathf.Abs(_rb.velocity.y) > tolerancia || Mathf.Abs(_rb.velocity.z) > tolerancia)
        {
            _animator.SetBool("move", true);
        }
        else
        {
            _animator.SetBool("move", false);
        }
        


    }
}
