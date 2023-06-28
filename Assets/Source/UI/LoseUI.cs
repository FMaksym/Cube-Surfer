using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LoseUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gamePanel;

    [Inject] private GameManager gameManager;

    void Update()
    {
        if (gameManager.GameOver)
        {
            StartCoroutine(ActivateLosePanel());
        }
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator ActivateLosePanel()
    {
        yield return new WaitForSeconds(1);
        _gamePanel.SetActive(false);
        _losePanel.SetActive(true);
    }
}
