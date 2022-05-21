using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public UI_ChipCount chipCountUI;
    public UI_GameResultUI gameResultUI;

    private User user = new User(-1);
    private int bettingType;
    private float bettingValue;

    #region Setting
    private GameManager()
    {
        //null
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetUser(User _user)
    {
        Debug.Assert(user.balance != -1, "Assert : Wrong balance : [" + user.balance + "] balance must bigger than -1");
        user = _user;
        chipCountUI.init();
    }

    public User GetUser()
    {
        return user;
    }
    #endregion Setting


    #region Betting System
    public void SetBetType(int _bettingType)
    {
        bettingType = _bettingType;
    }

    private int betResult = 0;
    public void Bet(float _bettingValue)
    {
        bettingValue = _bettingValue;

        Thread thread = new Thread(async () => { //언젠가 join 되겠지 뭐...
            betResult = await 자바스크립트함수(bettingType, bettingValue);
        });

        gameState = eGameState.WAITING_GAME_RESULT;
    }
    #endregion Betting System


    private enum eGameState { BETTING, WAITING_GAME_RESULT, RESULT }
    private eGameState gameState = eGameState.BETTING;
    private void Update()
    {
        switch (gameState)
        {
            case eGameState.BETTING:
                //베팅 가능한 상태
                //그냥 Block UI가 작동 안하는 상태라고 생각하면 됨
                break;
            case eGameState.WAITING_GAME_RESULT:
                if (betResult != 0) // 0이 아니면 콜백 js 코드가 끝난것
                {
                    gameResultUI.ResultSettingBy(betResult);
                    gameResultUI.gameObject.SetActive(true);
                    gameState = eGameState.RESULT;
                }
                else
                {
                    // RotateRoulette();
                }
                break;
            case eGameState.RESULT:
                //리워드 받고 베팅상태로 switch하기
                break;
        }
    }

    public void SwitchGameStateToBetting()
    { 
        chipCountUI.UpdateCnt(betResult); //결과값 Update
        bettingType = -1;
        bettingValue = -1;
        betResult = 0;
        gameState = eGameState.BETTING;
    }
}
