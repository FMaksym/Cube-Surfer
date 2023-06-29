using UnityEngine;
using Zenject;

public class CubeToAddController : MonoBehaviour
{
    [Inject]private PlayerBoxStack playerStack;
    private Vector3 direction = Vector3.back;

    public PlayerBoxStack playerBoxStack;

    private void Awake()
    {
        playerBoxStack = playerStack;
    }

    public void SetDirection()
    {
        direction = Vector3.forward;
    }
}
