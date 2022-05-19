using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_BettingBtn : MonoBehaviour
{
    public GameObject ErrorUI;
    public TMP_InputField bettingValue;
    public UI_Betting bettingUI;
    public User user;

    private void Start()
    {
        user = GameManager.instance.GetUser();
    }

    public void Bet()
    {
        float tryBetting = float.Parse(bettingValue.text);
        if (tryBetting > 0.0f && user.balance > tryBetting)
        {//안 걸거나 있는거보다 더 많이 걸려고 하지 않는다면
            GameManager.instance.Bet(tryBetting);
            bettingUI.gameObject.SetActive(false);
        }
        else
        {
            ErrorUI.SetActive(true);
        }
    }
}
