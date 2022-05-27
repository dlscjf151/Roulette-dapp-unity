using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Numerics;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public UI_ChipCount chipCountUI;
    public UI_GameResultUI gameResultUI;
	public OnBetResult onBetResult;

    private User user = new User(new BigInteger(0), "");
    private int bettingType;
    private BigInteger bettingValue;


#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void bet(string bettingValue, int bettingType);
#endif
    
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
        // Debug.Assert(user.balance != -1, "Assert : Wrong balance : [" + user.balance + "] balance must bigger than -1");
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

    public void Bet(BigInteger _bettingValue)
    {
        bettingValue = _bettingValue;

#if UNITY_WEBGL && !UNITY_EDITOR
        bet(bettingValue.ToString(), bettingType);
#else
		onBetResult.OnBet();
        onBetResult.OnResult((user.balance - 1).ToString());
#endif
        // update에서 상태를 확인하면서 결과를 기다리는 방식이 아닌
        // js 의 bet()를 호출하여 베팅을 진행하고 unity에서는 RotateRoulette을 호출해
        // 룰렛을 돌리고 있음 -> js 에서 bet의 결과가 나오면 listener로 결과를 전달해줌
        // listener에서 룰렛을 멈추고 결과를 띄우는 코드 실행

        // gameState = eGameState.WAITING_GAME_RESULT;
    }
    #endregion Betting System

    /*
    private enum eGameState { BETTING, WAITING_GAME_RESULT, RESULT }
    private eGameState gameState = eGameState.BETTING;
    private void Update()
    {
        
        switch (gameState)
        {
            case eGameState.BETTING:
                //���� ������ ����
                //�׳� Block UI�� �۵� ���ϴ� ���¶�� �����ϸ� ��
                break;
            case eGameState.WAITING_GAME_RESULT:
                if (betResult != 0) // 0�� �ƴϸ� �ݹ� js �ڵ尡 ������
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
                //������ �ް� ���û��·� switch�ϱ�
                break;
        }
    }
    */

    public void SwitchGameStateToBetting()
    { 
        bettingType = -1; 
        bettingValue = -1;
    }
}
