using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_Betting : MonoBehaviour
{
    public TMP_Text bettingTarget;

    private const string BET_TO_RED = "Betting To [RED]";
    private const string BET_TO_BLACK = "Betting To [BLACK]";

    public void Set(int _bettingType)
    {
        if (_bettingType == 1)
            bettingTarget.text = BET_TO_RED;
        else
            bettingTarget.text = BET_TO_BLACK;

        GameManager.instance.SetBetType(_bettingType);
    }
}
