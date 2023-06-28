using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void FixedUpdate()
    {
        CoinRotate();
    }

    private void CoinRotate()
    {
        transform.Rotate(new Vector3(0, 1, 0), _rotateSpeed * Time.fixedDeltaTime);
    }
}
