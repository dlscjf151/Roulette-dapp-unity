using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debugger
{
    public static void LogUsedInfo(User _userInfomation)
    {
        Debug.LogFormat("User info : [name : {0}], [balance : {1}]", _userInfomation.name,_userInfomation.balance);
    }
}
