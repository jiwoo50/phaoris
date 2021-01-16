using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    int nowCoins;
    private void Awake()
    {
        nowCoins = 0;
    }
    public void Deposit(int deposit)
    {
        nowCoins += deposit;
    }
    public void WithDraw(int withdraw)
    {
        nowCoins -= withdraw;
    }
    public int NowCoinsValue()
    {
        return nowCoins;
    }
}
