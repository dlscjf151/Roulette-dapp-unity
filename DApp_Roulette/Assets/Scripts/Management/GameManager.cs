using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static User user = new User("NONE",0 );
    public static void SetUser(User _user)
    {
        Debug.Assert(user.name.Equals("NONE"), "Assert : [SetUser] already called, plz call this function only once ");
        user = _user;
    }
    public static User GetUser()
    {
        return user;
    }
    #region Betting System
    public void Bet()
    {

    }

    public void CloseBets()
    {
        //블록체인에 어디에 얼마 걸었는지 전송
    }
    #endregion

    public UI_GameResultUI gameResultUI;
    public void WaitRouletteResult(bool win, float balanceChanged)
    {
        gameResultUI.gameObject.SetActive(true);
    }


}
