using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 75f;
    public Camera cam;

    private float _vInput;
    private float _hInput;
    private Animator animator;

    private void Start() 
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        var p = cam.transform.forward + this.transform.position;
        
        _hInput = Input.GetAxis("Horizontal") * rotationSpeed;
        _vInput = Input.GetAxis("Vertical") * moveSpeed;

        animator.SetFloat("direction", _vInput);

        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * (_hInput + p.y) * Time.deltaTime);

    }
}
