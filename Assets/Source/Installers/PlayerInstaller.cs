using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerBoxStack playerBox;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private Transform playerfollowPoint;

    public override void InstallBindings()
    {
        Container.Bind<PlayerBoxStack>().FromInstance(playerBox).AsSingle();
        Container.Bind<PlayerAnimation>().FromInstance(playerAnimation).AsSingle();
        Container.Bind<Transform>().FromInstance(playerfollowPoint).AsSingle();
    }
}