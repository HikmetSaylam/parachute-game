using UnityEngine;

public class FollowUp : MonoBehaviour
{
    [SerializeField] private GameObject followed;
    private Vector3 _offSet;
    private Transform _transform;
    
    
    private void Start()
    {
        _offSet = transform.position - followed.transform.position;
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.position = followed.transform.position + _offSet;
    }
}
