using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Numerics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public UI_ChipCount chipCountUI;
    public UI_GameResultUI gameResultUI;

    private User user = new User(new BigInteger(0), "");
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
    public void Bet(float _bettingValue)
    {
        bettingValue = _bettingValue;

        Thread thread = new Thread(async () => { //������ join �ǰ��� ��...
            //betResult = await �ڹٽ�ũ��Ʈ�Լ�(bettingType, bettingValue);
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

    public void SwitchGameStateToBetting()
    { 
        chipCountUI.UpdateCnt(betResult); //����� Update
        bettingType = -1;
        bettingValue = -1;
        betResult = 0;
        gameState = eGameState.BETTING;
    }
}
