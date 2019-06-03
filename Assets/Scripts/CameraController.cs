using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float rotationSpeed = 3f;
    private Vector3 distance;
    float desiredAngle;

    // Start is called before the first frame update
    void Start()
    {
        distance = target.transform.position - transform.position;
        desiredAngle = target.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        

        
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * distance);

        transform.LookAt(target.transform);

        if (Input.GetMouseButton(1))
        {
            Debug.Log("Right Click");
            desiredAngle = target.transform.eulerAngles.y;
            target.transform.Rotate(0, horizontal, 0);
        }
    }
}
