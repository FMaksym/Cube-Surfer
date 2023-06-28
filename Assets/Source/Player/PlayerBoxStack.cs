using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        gameManager.SetGameOver(false);
        UpdateTowerSize();
    }

    public void IncreaseTowerSize(GameObject block)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + _boxHeight * 1.5f, transform.position.z);

        //transform.Translate(0f, _boxHeight * 1.5f, 0f, Space.World);

        //block.transform.position = new Vector3(transform.position.x, _lastBox.transform.position.y - _boxHeight, transform.position.z);
        block.transform.position = new Vector3(_boxSpawnPos.transform.position.x, _lastBox.transform.position.y - _boxHeight, _boxSpawnPos.transform.position.z);
        //block.transform.localPosition = new Vector3(0f, -_boxHeight, 0f);
        //block.transform.position = _boxSpawnPos.position;
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
        _lastBox = _boxList[_boxList.Count-1];
    }

    public IEnumerator GameOver()
    {
        _animator.SetGameOverAnimation(true);
        gameManager.SetGameOver(true);
        Debug.Log(gameManager.GameOver);
        yield return new WaitForSeconds(1);
    }
}
