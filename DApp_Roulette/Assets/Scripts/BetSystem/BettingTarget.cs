using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettingTarget : MonoBehaviour
{

    public GameObject number = null;//후에 GameObject[]로 바꿔서 다중 베팅?

    int bettingType = -1;
    public UI_Betting bettingUI;
    public void Run()
    {
        Debug.Assert(((bettingType == 0) || (bettingType ==1)), "Assert : betting type was [NONE]");
        bettingUI.Set(bettingType);
        bettingUI.gameObject.SetActive(true);
    }

}
