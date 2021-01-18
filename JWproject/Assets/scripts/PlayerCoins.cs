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
        nowCoins = Mathf.Clamp(nowCoins+deposit, 0, 9999);
        coinsText.text = "Score : " + nowCoins.ToString();
    }
    public void WithDraw(int withdraw)
    {
        nowCoins = Mathf.Clamp(nowCoins-withdraw, 0, 9999);
        coinsText.text = "Coins : " + nowCoins.ToString();
    }
    public int NowCoinsValue()
    {
        return nowCoins;
    }
}
