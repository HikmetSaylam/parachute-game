using GeneralScripts;
using UnityEngine;

public class CharacterRotation : MonoSingleton<CharacterRotation>
{
    [SerializeField] private float startRotationX, endRotationX;
    [SerializeField] private float startRotationZ, endRotationZ;
    [SerializeField] private float disposition;
    private float _middleValue;
    private Quaternion _tmpRotation;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _tmpRotation = _transform.rotation;
        _middleValue = 0.5f;
    }
    
    
    private void FixedUpdate()
    {
        _tmpRotation.x = Mathf.Lerp(startRotationX, endRotationX,
            InputController.Instance.GetVertical() * disposition + _middleValue);
        _tmpRotation.y = InputController.Instance.GetRotationHorizontal() *2;
        _tmpRotation.z = -Mathf.Lerp(startRotationZ, endRotationZ,
            InputController.Instance.GetHorizontal()*disposition + _middleValue);
        _transform.rotation = _tmpRotation;
    }
}
