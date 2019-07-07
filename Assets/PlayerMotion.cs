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
    private float _rVInput;
    private Animator animator;

    private void Start() 
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        
        _hInput = Input.GetAxis("RightStickHorizontal") * rotationSpeed;
        _vInput = Input.GetAxis("LeftStickVertical") * moveSpeed;

        animator.SetFloat("direction", _vInput);

        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);

    }
}
