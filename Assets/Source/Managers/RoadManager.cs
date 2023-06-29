using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadManager : MonoBehaviour
{
    [Inject] public GameManager _gameManager;
    [Inject] public PlayerBoxStack _player;
    [Inject] private DiContainer _container;
    [SerializeField] private GameObject[] roadPrefabs;
    [SerializeField] private float roadDistance = 15.5f;
    [SerializeField] private float spawnDistance = 150f;
    [SerializeField] private float despawnDistance = 50f;
    [SerializeField] private int maxRoads = 15;
    [SerializeField] private Transform parentForSpawn;

    public List<GameObject> activeRoads = new List<GameObject>();
    public GameObject lastRoad;
    private Vector3 lastRoadPosition;

    private void Awake()
    {
        foreach (Road road in FindObjectsOfType<Road>())
        {
            activeRoads.Add(road.gameObject);
        }
        Vector3 lastRoadPosition = Vector3.zero;
        for (int i = 1; i < maxRoads; i++)
        {
            SpawnRoad(lastRoadPosition);
            lastRoadPosition += new Vector3(0, 0, roadDistance);
        }
    }

    private void Update()
    {
        if (!_gameManager.GameOver && _gameManager.GameStarted && !_gameManager.Pause)
        {
            
            if (activeRoads.Count-1 <= maxRoads)
            {
                lastRoadPosition = activeRoads[activeRoads.Count - 1].transform.position;

                float distanceToLastRoad = _player.transform.position.z - lastRoadPosition.z;
                Debug.Log(distanceToLastRoad);
                if (Mathf.Abs(distanceToLastRoad) >= spawnDistance)
                {
                    lastRoadPosition += new Vector3(0, 0, roadDistance);
                    SpawnRoad(lastRoadPosition);
                }
            }

            for (int i = 0; i < activeRoads.Count; i++)
            {
                float distanceToRoad = _player.transform.position.z - activeRoads[i].transform.position.z;
                if (distanceToRoad >= despawnDistance)
                {
                    DespawnRoad(i);
                    i--;
                }
            }
        }
    }

    private void SpawnRoad(Vector3 position)
    {
        int randomIndex = Random.Range(0, roadPrefabs.Length);

        GameObject newRoad = _container.InstantiatePrefab(roadPrefabs[randomIndex], position, Quaternion.identity, parentForSpawn);
        Road roadComponent = newRoad.GetComponent<Road>();
        roadComponent.Initialize(_player);

        activeRoads.Add(newRoad);
        lastRoadPosition += new Vector3(0, 0, roadDistance);
    }

    private void DespawnRoad(int index)
    {
        GameObject roadToRemove = activeRoads[index];
        activeRoads.RemoveAt(index);
        Destroy(roadToRemove);
    }
}
