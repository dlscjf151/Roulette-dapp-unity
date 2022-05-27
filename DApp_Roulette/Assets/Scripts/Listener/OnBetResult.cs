using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System.Numerics;

public class OnBetResult : MonoBehaviour
{
    public UI_GameResultUI gameResultUI;
	public UI_Betting bettingUI;
	public UI_BettingBtn bettingBtnUI;
    public UI_Roulette rouletteUI;
    

    public void OnBet()
    {
        bettingUI.gameObject.SetActive(false);
		bettingBtnUI.bettingValue.text = "";
        rouletteUI.gameObject.SetActive(true);
    }

    public void OnResult(string balance)
    {
        rouletteUI.gameObject.SetActive(false);
        gameResultUI.ResultSettingBy(balance);
        gameResultUI.gameObject.SetActive(true);
#if !(UNITY_WEBGL && !UNITY_EDITOR)
        User user = GameManager.instance.GetUser();
        user.balance = BigInteger.Parse(balance);
        GameManager.instance.SetUser(user);
#endif

    }
}