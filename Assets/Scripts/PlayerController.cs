using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tolerancia;

    public float DashDistance = 5f;

    public const float maxDashTime = 100.0f;
    public float dashStoppingSpeed = 0.001f;
    public float dashSpeed = 100;

    private Rigidbody _rb;
    private Animator _animator;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _rb.drag = 15;
    
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized; ;

        if (movement != Vector3.zero)
        {
            this.transform.forward = movement;
        }

        //_rb.velocity = movement * speed;
        _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);


        
        if (Mathf.Abs(horizontal) > tolerancia || Mathf.Abs(vertical) > tolerancia)
        {
            _animator.SetBool("move", true);
        }
        else
        {
            _animator.SetBool("move", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _rb.drag + 1)) / -Time.deltaTime)));
            _rb.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }


    /*
    IEnumerator Dash()
    {
        float dashTime = 0;
       
        _rb.velocity = this.transform.forward * dashSpeed;
        while (dashTime < maxDashTime)
        {
            dashTime += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
            //_rb.velocity = this.transform.forward * dashSpeed;
        }
        _rb.AddForce(0,0,0);
        
        //_rb.velocity = this.transform.forward * dashSpeed;
    }*/
}
