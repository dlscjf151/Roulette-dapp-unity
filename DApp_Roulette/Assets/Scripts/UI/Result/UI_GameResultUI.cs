using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using System.Runtime.InteropServices;

public class UI_GameResultUI : MonoBehaviour
{
    public TMP_Text win_or_lose;
    public TMP_Text beforeEth;
    public TMP_Text afterEth;

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string fromWei(string wei);
#endif

    public void ResultSettingBy(string balance)
    {
        User user = GameManager.instance.GetUser();
        if (BigInteger.Parse(balance) > user.balance)
        {
            win_or_lose.text = "WIN";
        }
        else
        {
            win_or_lose.text = "LOSE";
        }

#if UNITY_WEBGL && !UNITY_EDITOR
		string before = fromWei(user.balance.ToString());
        if (before.Contains('.'))
        {
            int index = before.IndexOf(".");
            int end = before.Length; 
            before = before.Substring(0, index+5 > end ? end : index+5);
        }
#else
		string before = user.balance.ToString();
#endif

        beforeEth.text = before;
		
#if UNITY_WEBGL && !UNITY_EDITOR
		string after = fromWei(balance);
        if (after.Contains('.'))
        {
            int index = before.IndexOf(".");
            int end = after.Length; 
            after = after.Substring(0, index+5 > end ? end : index+5);
        }
#else
		string after = user.balance.ToString();
#endif
        afterEth.text = after;
    }
}
