using UnityEngine;
using System.Collections;

public class CharacterLogicController : MonoBehaviour
{
  
    [SerializeField] private float _directionDampTime = .25f;
    [SerializeField] private Animator _animator;
    private float _speed = 0.0f;
    private float _h = 0.0f;
    private float _v = 0.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        if(_animator.layerCount >= 2)
        {
            _animator.SetLayerWeight(1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_animator)
        {
            _h = Input.GetAxis("Horizontal");
            _v = Input.GetAxis("Vertical");          

            _speed = new Vector2(_h, _v).sqrMagnitude;

            Debug.Log(_speed);

            _animator.SetFloat("Speed", _speed);
            _animator.SetFloat("Direction", _h, _directionDampTime, Time.deltaTime);
        }
    }

}
