using UnityEngine;
using Zenject;

public class WaterController : MonoBehaviour
{
    public float speed = 5f; 
    public float spawnPositionX = -750f; 
    public GameObject planePrefab; 

    [Inject] private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); 

        if (transform.position.x <= spawnPositionX) 
        {
            planePrefab.transform.position = new Vector3(0f, transform.position.y, transform.position.z); ;
        }
    }
}
