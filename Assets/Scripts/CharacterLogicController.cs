using UnityEngine;
using System.Collections;

public class CharacterLogicController : MonoBehaviour
{
  
    [SerializeField] private float _directionDampTime = .25f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float directionSpeed;
    private float _speed = 0.0f;
    private float horizontal = 0.0f;
    private float vertical = 0.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_animator)
        {
            horizontal = Input.GetAxis("Horizontal");
            _animator.SetFloat("InputZ", horizontal);

            vertical = Input.GetAxis("Vertical");          
            _animator.SetFloat("InputX", vertical);


        }
    }

    public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut)
    {
        Vector3 rootDirection = root.forward;
        Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
        speedOut = stickDirection.sqrMagnitude;

        // Get camera rotation
        Vector3 CameraDirection = camera.forward;
        CameraDirection.y = 0.0f;
        Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, CameraDirection);

        // Convert joystick input in Worldspace coords
        Vector3 moveDirection = referentialShift * stickDirection;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);

        float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);
        angleRootToMove /= 180f;
        directionOut = angleRootToMove * directionSpeed;
    }
}
