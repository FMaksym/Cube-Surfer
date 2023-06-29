using UnityEngine;
using Zenject;

public class MovementPlayer : MonoBehaviour
{
    [Inject] private GameManager gameManager;


    [SerializeField] private enum ControllType
    {
        MousePC,
        Mobile
    };

    [Header("Player Movement Speed")]
    [SerializeField] private float _forwardMovementSpeed;
    [SerializeField] private float _horizontalMovementSpeed;
    [Header("Player Movement Speed")]
    [SerializeField] private float _limitHorizontalPosition;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ControllType _controllType;
    private float _horizontalValue;
    private float _newPositionX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager.SetGameOver(false);
        if (IsMobileDevice())
        {
            _controllType = ControllType.Mobile;
        }
        else
        {
            _controllType = ControllType.MousePC;
        }
    }

    private bool IsMobileDevice()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return false;
#elif UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
    return true;
#else
    return false;
#endif
    }

    private void Update()
    {
        if (gameManager.GameStarted && !gameManager.GameOver && !gameManager.Pause)
        {
            HandlePlayerHorizontalInput();
            Move();
            //ForwardMovement();
            //HorizontalMovement();
        }
    }

    private void HandlePlayerHorizontalInput()
    {
        if (_controllType == ControllType.MousePC)
        {
            PcInput();
        }
        else
        {
            MobileInput();
        }
    }

    private void PcInput()
    {
        //_forwardMovementSpeed = 2.5f;
        _horizontalMovementSpeed = 15f;
        if (Input.GetMouseButton(0))
        {
            _horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            _horizontalValue = 0;
        }
    }

    private void MobileInput()
    {
        _forwardMovementSpeed = 3f;
        _horizontalMovementSpeed = 250f;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _horizontalValue = touch.deltaPosition.x / Screen.width;
                _horizontalValue = Mathf.Clamp(_horizontalValue, -1f, 1f);
            }
        }
        else
        {
            _horizontalValue = 0f;
        }
    }

    //private void ForwardMovement()
    //{
    //    transform.Translate(Vector3.forward * _forwardMovementSpeed * Time.deltaTime);
    //}

    //private void HorizontalMovement()
    //{
    //    _newPositionX = transform.position.x + _horizontalValue * _horizontalMovementSpeed * Time.fixedDeltaTime;
    //    _newPositionX = Mathf.Clamp(_newPositionX, -_limitHorizontalPosition, _limitHorizontalPosition);
    //    transform.position = new Vector3(_newPositionX, transform.position.y, transform.position.z);
    //}

    private void Move()
    {
        HorizontalMovement();
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        Vector3 movement = transform.forward * _forwardMovementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void HorizontalMovement()
    {
        float newPositionX = _rigidbody.position.x + _horizontalValue * _horizontalMovementSpeed * Time.deltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -_limitHorizontalPosition, _limitHorizontalPosition);
        _rigidbody.MovePosition(new Vector3(newPositionX, transform.position.y, transform.position.z));
    }
}
