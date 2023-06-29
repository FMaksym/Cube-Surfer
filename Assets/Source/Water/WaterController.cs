using UnityEngine;
using Zenject;

public class WaterController : MonoBehaviour
{
    public float _moveToLeftSpeed = 5f; 
    public float _moveToForwarSpeed = 5f; 
    public float spawnPositionX = -750f; 
    public GameObject planePrefab; 

    [Inject] private GameManager gameManager;
    [Inject] private PlayerBoxStack player;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        MoveToLeft(_moveToLeftSpeed);
    }

    private void MoveToLeft(float speed)
    {
        transform.Translate(Vector3.left * _moveToForwarSpeed * Time.deltaTime);
        if (!gameManager.GameOver)
        {
            planePrefab.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
        }

        if (transform.position.x <= spawnPositionX)
        {
            planePrefab.transform.position = new Vector3(0f, transform.position.y, player.transform.position.z); ;
        }
    }
}
