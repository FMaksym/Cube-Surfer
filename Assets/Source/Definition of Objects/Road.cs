using UnityEngine;
using Zenject;

public class Road : MonoBehaviour
{
    [Inject] public PlayerBoxStack playerBoxStack;

    public void Initialize(PlayerBoxStack _playerBoxStack) 
    {
        playerBoxStack = _playerBoxStack;
    }
}
