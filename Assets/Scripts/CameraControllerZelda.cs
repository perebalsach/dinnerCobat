using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerZelda : MonoBehaviour
{

    [SerializeField] private float distanceAway;
    [SerializeField] private float distanceUp;
    [SerializeField] private float smooth;
    [SerializeField] private Transform follow;
    [SerializeField] private Transform character;

    private Vector3 _targetPosition;
    

    private void LateUpdate()
    {

        follow.transform.position = character.transform.forward;
        _targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * smooth);
        transform.LookAt(follow);
    }
}
