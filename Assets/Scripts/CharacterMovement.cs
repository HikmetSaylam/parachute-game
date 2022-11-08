using GeneralScripts;
using UnityEngine;

public class CharacterMovement : MonoSingleton<CharacterMovement>
{
    [SerializeField] private int speed;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    [SerializeField] private float difficultyOfControl;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _direction.x = InputController.Instance.GetHorizontal();
        _direction.y = CharacterPhysic.Instance.Drop();
        _direction.z = InputController.Instance.GetVertical();
        if (_direction.magnitude >= 0)
        {
            _direction.x += InputController.Instance.GetRotationHorizontal() * 2;
        }
        _direction.x *= speed;
        _direction.z *= speed;
        if (CharacterPhysic.Instance.GetIsParachuteOpen())
        {
            _direction.x /= difficultyOfControl;
            _direction.z /= difficultyOfControl;
        }
        _rigidbody.velocity = _direction;
    }
}
