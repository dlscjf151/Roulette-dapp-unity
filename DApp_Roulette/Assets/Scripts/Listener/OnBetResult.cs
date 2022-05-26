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
    
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string fromWei(string ether);
#endif

    public void OnBet()
    {
        bettingUI.gameObject.SetActive(false);
		bettingBtnUI.bettingValue.text = "";
		// RotateRoulette()
    }

    public void OnResult(string balance)
    {
        gameResultUI.ResultSettingBy(balance);
        gameResultUI.gameObject.SetActive(true);
    }
}