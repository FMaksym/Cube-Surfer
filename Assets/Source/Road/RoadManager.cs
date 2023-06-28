using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class RoadManager : MonoBehaviour
{
    [Inject] public GameManager _gameManager;
    [Inject] public PlayerBoxStack _player;
    [SerializeField] private GameObject[] roadPrefabs;
    [SerializeField] private float roadDistance = 15.5f;
    [SerializeField] private float spawnDistance = 150f;
    [SerializeField] private float despawnDistance = 50f;
    [SerializeField] private int maxRoads = 15;
    [SerializeField] private Transform parentForSpawn;

    public List<GameObject> activeRoads = new List<GameObject>();

    public GameObject lastRoad;

    [Inject] private DiContainer _container;
    private Vector3 lastRoadPosition;

    private void Awake()
    {
        // Генерируем и добавляем префабы дороги в список activeRoads
        Vector3 lastRoadPosition = Vector3.zero;
        for (int i = 0; i < maxRoads; i++)
        {
            SpawnRoad(lastRoadPosition);
            lastRoadPosition += new Vector3(0, 0, roadDistance);
        }
    }

    private void Update()
    {
        if (!_gameManager.GameOver && _gameManager.GameStarted && !_gameManager.Pause)
        {
            // Проверяем количество префабов на сцене
            if (activeRoads.Count < maxRoads)
            {
                // Получаем позицию последнего префаба дороги
                lastRoadPosition = activeRoads[activeRoads.Count - 1].transform.position;

                // Вычисляем дистанцию от игрока до последнего префаба
                float distanceToLastRoad = _player.transform.position.z - lastRoadPosition.z;

                // Проверяем, достигла ли дистанция и требуется ли спавн нового префаба
                if (distanceToLastRoad >= spawnDistance)
                {
                    lastRoadPosition += new Vector3(0, 0, roadDistance);
                    SpawnRoad(lastRoadPosition);
                }
            }

            // Проверяем дистанцию от игрока до префабов и удаляем, если необходимо
            for (int i = 0; i < activeRoads.Count; i++)
            {
                float distanceToRoad = _player.transform.position.z - activeRoads[i].transform.position.z;
                if (distanceToRoad >= despawnDistance)
                {
                    DespawnRoad(i);
                    i--; // Уменьшаем индекс, чтобы не пропустить следующий элемент после удаления
                }
            }
        }
    }

    private void SpawnRoad(Vector3 position)
    {
        int randomIndex = Random.Range(0, roadPrefabs.Length);
        // Создание нового префаба дороги
        //GameObject newRoad = _container.InstantiatePrefab(roadPrefabs[randomIndex], position, Quaternion.identity, parentForSpawn).GetComponent<Road>().Initialize(_player);

        GameObject newRoad = _container.InstantiatePrefab(roadPrefabs[randomIndex], position, Quaternion.identity, parentForSpawn);
        Road roadComponent = newRoad.GetComponent<Road>();
        roadComponent.Initialize(_player);

        activeRoads.Add(newRoad);
        lastRoadPosition += new Vector3(0, 0, roadDistance);
    }

    private void DespawnRoad(int index)
    {
        // Удаляем префаб дороги из списка activeRoads и уничтожаем его
        GameObject roadToRemove = activeRoads[index];
        activeRoads.RemoveAt(index);
        Destroy(roadToRemove);
    }
}
//container.InstantiatePrefab(policeCarPrefab, spawnPoint.position, spawnPoint.rotation, parentTransform)
//                    .GetComponent<PoliceCar>()
//                    .Initialize(carController);
