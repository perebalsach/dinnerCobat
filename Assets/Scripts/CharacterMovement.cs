using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator _animator;
    private float _horizontal;
    private float _vertical;

    void Start()
    {
        _animator = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
         _horizontal = Input.GetAxis("Horizontal");
        _animator.SetFloat("direction", _horizontal);

        _vertical = Input.GetAxis("Vertical");          
        _animator.SetFloat("speed", _vertical);

    }
}
