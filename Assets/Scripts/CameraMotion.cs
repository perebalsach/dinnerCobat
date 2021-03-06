﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public float distanceAway;
    public float startDistanceUp;
    public float distanceUpSpeed;
    public float smooth;
    public float yOffset;
    public float _height;

    private Vector3 _targetPosition;
    private Transform _follow;
    private float _rVInput;


    private void Start() 
    {
        _follow = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        _rVInput = Input.GetAxis("RightStickVertical");
        startDistanceUp += _rVInput * distanceUpSpeed;
        
        Debug.Log(startDistanceUp);
        
        if (startDistanceUp > .1)
        {
            _targetPosition = _follow.position + _follow.up * startDistanceUp - _follow.forward * distanceAway;
            transform.position = Vector3.Lerp(_targetPosition, transform.position, Time.deltaTime * smooth);
            transform.position = new Vector3(transform.position.x, 
                                                transform.position.y + yOffset,
                                                transform.position.z
                                                );

            var _followOffset = new Vector3(_follow.transform.position.x, _height, _follow.transform.position.z);
            transform.LookAt(_followOffset);
        }
        

        // this.transform.position = new Vector3(Player.transform.position.x, 
        //                                         Player.transform.position.y + YOffset,
        //                                         Player.transform.position.z + ZOffset
        //                                     );

        // var lookAt = new Vector3(Player.transform.position.x, 
        //                             Player.transform.position.y + OffsetTargetY,
        //                             Player.transform.position.z
        //                         );

        // this.transform.LookAt(lookAt);
    }
}
