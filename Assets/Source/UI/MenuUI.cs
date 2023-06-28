using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;

    [Header("Buttons")]
    [SerializeField] private Button _soundButton;

    [Header("Images")]
    [SerializeField] private Sprite _soundOnImage;
    [SerializeField] private Sprite _soundOffImage;

    private bool IsSound = true;

    [Inject] private GameManager gameManager;
    [Inject] private PlayerAnimation playerAnimation;

    public void OnClickPlay()
    {
        playerAnimation.SetStartGameAnimation(true);
        gameManager.StartGame(true);
        _menuPanel.SetActive(false);
        _gamePanel.SetActive(true);
    }

    public void OnClickSettings()
    {
        if (!_soundButton.gameObject.activeSelf)
        {
            _soundButton.gameObject.SetActive(true);
        }
        else
        {
            _soundButton.gameObject.SetActive(false);
        }
    }
    
    public void OnClickSound()
    {
        if (IsSound)
        {
            IsSound = false;
            _soundButton.image.sprite = _soundOffImage;
        }
        else
        {
            IsSound = true;
            _soundButton.image.sprite = _soundOnImage;
        }
    }
}
