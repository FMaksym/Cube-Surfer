using UnityEngine;
using Zenject;

public class CubeTrigger : MonoBehaviour
{
    public bool IsStack;
    [SerializeField] private AddBlockEffect floatingText;
    [SerializeField] private CubeToAddController cubeToAddController;
    [Inject] public PlayerBoxStack playerBox;

    //private Road road;

    //private void Start()
    //{
    //    road = GetComponentInParent<Road>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBoxStack>() || other.gameObject.GetComponent<CubeToAdd>())
        {
            if (!IsStack)
            {
                IsStack = true;

                playerBox.IncreaseTowerSize(gameObject);
                cubeToAddController.SetDirection();
            }
        }
        if (other.gameObject.GetComponent<ObstacleCube>())
        {
            playerBox.DecreaseTowerSize(gameObject);
        }

        if (other.gameObject.GetComponent<Coin>())
        {
            Destroy(other.gameObject);
        }
    }
}
