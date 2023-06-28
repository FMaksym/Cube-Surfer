using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gamePanel;

    [Inject] private GameManager gameManager;

    public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickResume()
    {
        gameManager.SetPause(false);
        _pausePanel.SetActive(false);
        _gamePanel.SetActive(true);
    }
}
