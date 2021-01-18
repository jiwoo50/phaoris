using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCoins : MonoBehaviour
{
    public Text coinsText;
    int nowCoins;
    private void Awake()
    {
        nowCoins = 0;
    }
    public void Deposit(int deposit)
    {
        nowCoins += deposit;
        coinsText.text = "Score : " + nowCoins.ToString();
    }
    public void WithDraw(int withdraw)
    {
        nowCoins -= withdraw;
        coinsText.text = "Coins : " + nowCoins.ToString();
    }
    public int NowCoinsValue()
    {
        return nowCoins;
    }
}
