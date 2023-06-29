using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBoxStack : MonoBehaviour
{
    [Inject] private GameManager gameManager;
    [SerializeField] private List<GameObject> _boxList = new List<GameObject>();
    [SerializeField] private float _boxHeight;
    public GameObject _lastBox;
    public Transform _boxSpawnPos;
    public Transform _tower;
    [Header("Player Animator")]
    [SerializeField] private PlayerAnimation _animator;
    [SerializeField] private AddBlockEffect floatingText;
    [SerializeField] public TrailRenderer _cubeTrail;
    private Vector3 _trailInitialPosition;
    private Vector3 _cubeTrailInitialPosition;

    private void Start()
    {
        gameManager.SetGameOver(false);
        _lastBox = _boxList[_boxList.Count - 1];
        //_trailInitialPosition = new Vector3(_cubeTrail.transform.position.x, _cubeTrail.transform.position.y, _cubeTrail.transform.position.z);
        _trailInitialPosition = _cubeTrail.transform.position;
        _cubeTrailInitialPosition = _cubeTrail.transform.localPosition;
    }

    public void IncreaseTowerSize(GameObject block)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + _boxHeight * 1.5f, transform.position.z);
        block.transform.position = new Vector3(_boxSpawnPos.transform.position.x, _lastBox.transform.position.y - _boxHeight, _boxSpawnPos.transform.position.z);
        floatingText.ShowFloatingText(block.transform.position);
        block.transform.SetParent(_tower);
        _boxList.Add(block);
        UpdateTowerSize();
    }

    public void DecreaseTowerSize(GameObject block)
    {
        block.transform.parent = null;
        _boxList.Remove(block);
        UpdateTowerSize();
        if (gameManager.GameOver == false)
        {
            Destroy(block, 5f);
        }
    }

    private void UpdateTowerSize()
    {
        _lastBox = _boxList[_boxList.Count - 1];
        Vector3 newTrailPosition = new Vector3(_cubeTrailInitialPosition.x, _trailInitialPosition.y, _cubeTrailInitialPosition.z);
        newTrailPosition = transform.TransformPoint(newTrailPosition);
        _cubeTrail.transform.position = newTrailPosition;
    }

    public IEnumerator GameOver()
    {
        _animator.SetGameOverAnimation(true);
        gameManager.SetGameOver(true);
        if (Application.isMobilePlatform)
        {
            Handheld.Vibrate();
        }
        yield return new WaitForSeconds(1);
    }
}
