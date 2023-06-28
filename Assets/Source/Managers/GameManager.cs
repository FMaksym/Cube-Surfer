using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameStarted { get; private set; }
    public bool GameOver { get; private set; }
    public bool Pause { get; private set; }

    public void StartGame(bool value)
    {
        GameStarted = value;
    }

    public void SetGameOver(bool value)
    {
        GameOver = value;
    }

    public void SetPause(bool value)
    {
        Pause = value;
    }
}
