using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 75f;

    private float _vInput;
    private float _hInput;

    void Update()
    {
        _hInput = Input.GetAxis("Horizontal") * rotationSpeed;
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }
}
