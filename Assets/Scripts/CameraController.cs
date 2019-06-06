using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public GameObject bossTaregt;
    public float rotationSpeed = 3f;
    private Vector3 distance;
    float desiredAngle;

    private GameObject viewTarget;
    private bool pointBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        viewTarget = target;
        distance = target.transform.position - transform.position;
        desiredAngle = target.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;



        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * distance);

        transform.LookAt(viewTarget.transform);

        if (Input.GetMouseButton(1))
        {
            desiredAngle = target.transform.localEulerAngles.y;
            target.transform.Rotate(0, horizontal, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            desiredAngle = target.transform.localEulerAngles.y;
            target.transform.Rotate(0, horizontal, 0);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Target BOSS!");
            if (!pointBoss)
            {
                viewTarget = bossTaregt;
            }
            else
            {
                viewTarget = target;
            }
            pointBoss = !pointBoss;            
        }
    }
}
