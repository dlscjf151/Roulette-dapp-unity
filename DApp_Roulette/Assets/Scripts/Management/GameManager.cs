using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Setting
    private GameManager() { }
    private void Awake()
    {
        if (instance != null)
        {
            instance = new GameManager();
        }
    }
    private User user = new User("NONE", 0);
    public void SetUser(User _user)
    {
        Debug.Assert(user.name.Equals("NONE"), "Assert : [SetUser] already called, plz call this function only once ");
        user = _user;
    }
    public User GetUser()
    {
        return user;
    }
    #endregion

    #region Betting System
    public void Bet(BettingTarget.eBettingType _bettingType)
    {
        // 블록체인한테 데이터 어떻게 얼마나 줄지 모르겠음
    }

    public void CloseBets()
    {
        //블록체인에 어디에 얼마 걸었는지 전송
        //await하고 update 돌면서 데이터 들어오길 기다리는 쓰레드 생성 혹은 순수하게 기다리기
        // 여기 설계 더 필요
    }
    #endregion

    public UI_GameResultUI gameResultUI;
    public void WaitRouletteResult(bool win, float balanceChanged)
    {//await? async?
        gameResultUI.gameObject.SetActive(true);
    }

    private enum eGameState 
    { 
        BETTING,
        WAITING
    }

}
