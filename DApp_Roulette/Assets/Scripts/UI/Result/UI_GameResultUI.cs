using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_GameResultUI : MonoBehaviour
{
    public TMP_Text win_or_lose;
    public TMP_Text beforeEth;
    public TMP_Text afterEth;

    public void ResultSettingBy(float _balanceChanged)
    {
        if (_balanceChanged > 0)
        {
            win_or_lose.text = "WIN";
        }
        else
        {
            win_or_lose.text = "LOSE";
        }

        User user = GameManager.instance.GetUser();
        beforeEth.text = user.balance.ToString();
        user.balance += _balanceChanged;
        afterEth.text = user.balance.ToString();
    }
}
