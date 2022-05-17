using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_GameResultUI : MonoBehaviour
{
    public TMP_Text win_or_lose;
    public TMP_Text balanceChanged;
    public TMP_Text Resultbalance;


    public void ResultSetting(float _balanceChanged)
    {
        if(_balanceChanged>0)
        {
            win_or_lose.text = "WIN";
        }
        else
        {
            win_or_lose.text = "LOSE";
        }

        balanceChanged.text = _balanceChanged.ToString();

        User user = GameManager.GetUser();
        user.balance += _balanceChanged;
        Resultbalance.text = user.balance.ToString(); 
    }
}
