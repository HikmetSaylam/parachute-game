using UnityEngine;

public class FollowUp : MonoBehaviour
{
    [SerializeField] private Transform followed;
    [SerializeField] private float startRotaXPoint;
    [SerializeField] private float endRotaXPoint;
    [SerializeField] private float turnSmoothTime;
    private Vector3 _offSet;
    private Transform _transform;
    private Vector3 _tmpRotation;
    private float _middleValue;
    private float _turnSmoothVelocity;


    private void Start()
    {
        _offSet = transform.position - followed.position;
        _transform = transform;
        _middleValue = 0.5f;
    }

    private void FixedUpdate()
    {
        _transform.position = followed.position + _offSet;
        _tmpRotation.x = Mathf.Lerp(startRotaXPoint, endRotaXPoint,
            -(InputController.Instance.GetVertical() / 2) + _middleValue);
        _tmpRotation.x = Mathf.SmoothDampAngle(_transform.rotation.x, _tmpRotation.x,
            ref _turnSmoothVelocity, turnSmoothTime);
        _tmpRotation.y = _transform.rotation.y;
        _tmpRotation.z = _transform.rotation.z;
        _transform.localEulerAngles=_tmpRotation;
    }
}
