using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public delegate void BankHendler(int OldCoinValue, int newCoinsValue);
    public event BankHendler OnCoinValueChangedEvent;
    public event Action<int, int> OnCoinValueChangedActionEvent;

    public int coins;

    public int Coin
    {
        get => coins;
        set
        {
            coins = PlayerPrefs.GetInt("Coins");

        }
    }

    public void AddCoins(int amount)
    {
        coins = PlayerPrefs.GetInt("Coins");
        var oldCoinsValue = Coin;
        coins += amount;
        Debug.Log("Coins amount + " + coins);
        PlayerPrefs.SetInt("Coins", coins);
        OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coin);
        OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coin);
    }

    public void SpendCoins(int amount)
    {
        var oldCoinsValue = Coin;
        coins -= amount;
        PlayerPrefs.SetInt("Coins", coins);
                                                                                                                                 
        OnCoinValueChangedEvent?.Invoke(oldCoinsValue, Coin);
        OnCoinValueChangedActionEvent?.Invoke(oldCoinsValue, Coin);
    }

    public bool IsEnought(int amount)
    {
        Coin = PlayerPrefs.GetInt("Coins");
        return Coin >= amount;
    }
}
