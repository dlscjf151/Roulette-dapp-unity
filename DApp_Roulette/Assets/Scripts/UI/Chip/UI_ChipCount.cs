using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_ChipCount : MonoBehaviour
{
    public TMP_Text chipCount;
    private float eth = 0;
    //칩 몇개까지 보여주지? 몇 이더여야되지?
    //일단 한 10 이더 쓴다고 생각하고 하자

    public void init()
    {
        eth = GameManager.instance.GetUser().balance;
        chipCount.text = eth.ToString();
    }

    public void UpdateCnt(float _bettingValue)
    {
        eth += _bettingValue;
        chipCount.text = "x"+eth;
    }
}
