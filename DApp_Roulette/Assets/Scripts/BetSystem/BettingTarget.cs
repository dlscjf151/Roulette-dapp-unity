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

    public GameObject number = null;//후에 GameObject[]로 바꿔서 다중 베팅
    private static GameManager gameManager;
    private eBettingType bettingType = eBettingType.NONE;

    public void Start()
    {
        gameManager = GameManager.instance;
    }

    public void SetBettingType(eBettingType _bettingType)
    {
        bettingType = _bettingType;
    }

    public void Run()
    {
        Debug.Assert(number != null, "Assert : BettingTarget can't be [null] from : " + name);
        Debug.Assert(bettingType!= eBettingType.NONE, "Assert : BettingTarget Type can't be [NONE] from : " + name);
        gameManager.Bet(bettingType);
    }

}
