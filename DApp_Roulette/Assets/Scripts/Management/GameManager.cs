using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    #region Setting
    private GameManager() { }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private User user = new User("NONE", 0);
    public void SetUser(User _user)
    {
        Debug.Assert(user.name.Equals("NONE"), "Assert : [SetUser] already called, plz call this function only once ");
        user = _user;
        chipCountUI.init();
    }
    public User GetUser()
    {
        return user;
    }
    #endregion

    #region Betting System

    public UI_ChipCount chipCountUI;
    private BettingTarget.eBettingType bettingType;
    private float bettingValue;
    public void SetBetType(BettingTarget.eBettingType _bettingType)
    {
        bettingType = _bettingType;
    }

    public void Bet(float _bettingValue)
    {
        //UI update 
        bettingValue = _bettingValue;
        // _bettingValue, bettingType을 블록체인으로 전송(how?)

        gameState = eGameState.WAITING_GAME_RESULT;
    }
    #endregion

    public UI_GameResultUI gameResultUI;
    public void WaitRouletteResult(bool _win, float _balanceChanged)
    {//await? async?
        gameResultUI.gameObject.SetActive(true);
    }


    private enum eGameState { BETTING, WAITING_GAME_RESULT, REWARDING }
    private eGameState gameState = eGameState.BETTING;
    private void Update()
    {
        switch (gameState)
        {
            case eGameState.BETTING:
                //베팅 가능한 상태
                //그냥 Block UI가 작동 안하는 상태라고 생각하면 됨
                //ClostBetting하면 Waiting state로 switch
                break;
            case eGameState.WAITING_GAME_RESULT:
                //신호 올 때까지 룰렛 돌리고있기
                // RotateRoulette();
                // if (WaitSingal()) 신호 accept하면 Rewardig으로 switch
                gameResultUI.ResultSettingBy(bettingValue);//블록체인에서 받은 값으로 세팅해야됨. 일단 그냥 세팅중
                gameResultUI.gameObject.SetActive(true);
                gameState = eGameState.REWARDING;
                break;
            case eGameState.REWARDING:
                //리워드 받고 베팅상태로 switch하기
                //리워드 창 말고 뭐 만지면 안됨 block UI 필요
                // RewardUI.Close하면 베팅 상태로 switch
                break;
        }

    }
    public void SwitchGameStateToBetting()
    {//칩 카운트 재조정, 칩 GameObject 치우기, 
     //chipCountUI.UpdateCnt( ... ); 결과값 Update
        gameState = eGameState.BETTING;
    }
}
