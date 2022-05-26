using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using System.Runtime.InteropServices;

public class UI_BettingBtn : MonoBehaviour
{
    public GameObject ErrorUI;
    public TMP_InputField bettingValue;
    public UI_Betting bettingUI;
    public User user;

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string toWei(string ether);
#endif
    
    private void Start()
    {
        user = GameManager.instance.GetUser();
    }

    public void Bet()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string _bettingValue = bettingValue.text;
        BigInteger tryBetting = BigInteger.Parse(toWei(_bettingValue));
#else
        BigInteger tryBetting = BigInteger.Parse(bettingValue.text);
#endif
        user = GameManager.instance.GetUser();
		Debug.Log(tryBetting);
		Debug.Log(user.balance);
#if UNITY_WEBGL && !UNITY_EDITOR
        if (tryBetting > new BigInteger(0)  && user.balance > tryBetting && 
			tryBetting % BigInteger.Parse(toWei("0.0001")) == 0)
#else
        if (tryBetting > new BigInteger(0)  && user.balance > tryBetting )
#endif
        {
            GameManager.instance.Bet(tryBetting);
            // bettingUI.gameObject.SetActive(false);
        }
        else
        {
            ErrorUI.SetActive(true);
        }
    }
}
