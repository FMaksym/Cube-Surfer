using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public GameManager gameManager;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
    }
}