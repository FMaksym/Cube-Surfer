using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameUI : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    [Header("Panels")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gamePanel;

    public void OnClickPause()
    {
        gameManager.SetPause(true);
        _gamePanel.SetActive(false);
        _pausePanel.SetActive(true);
    }
}
