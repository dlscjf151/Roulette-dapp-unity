using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettingTarget : MonoBehaviour
{
    public enum eBettingType
    {
        NONE,
        RED,
        BLACK
    }

    public GameObject number = null;//후에 GameObject[]로 바꿔서 다중 베팅?
    public eBettingType bettingType = eBettingType.NONE;

    public UI_Betting bettingUI;
    public void Run()
    {
        Debug.Assert(bettingType != eBettingType.NONE, "Assert : betting type was [NONE]");
        bettingUI.Set(bettingType);
        bettingUI.gameObject.SetActive(true);
    }

}
