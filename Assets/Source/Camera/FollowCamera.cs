using UnityEngine;
using Zenject;

public class FollowCamera : MonoBehaviour
{
    [Inject] public PlayerBoxStack _player;
    [Inject] public Transform _followPoint;

    private Vector3 _offset;
    private Vector3 _newPosition;

    [SerializeField] private float _lertValue;

    private void Start()
    {
        _offset = transform.position - _followPoint.transform.position;
    }

    private void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        float targetZ = _followPoint.transform.position.z + _offset.z;
        _newPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _followPoint.transform.position.y + _offset.y, targetZ), _lertValue * Time.deltaTime);
        //_newPosition = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z) + _offset, _lertValue * Time.deltaTime);
        transform.position = _newPosition;
    }
}

