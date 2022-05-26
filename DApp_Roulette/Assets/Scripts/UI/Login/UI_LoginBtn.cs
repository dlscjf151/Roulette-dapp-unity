using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using System.Runtime.InteropServices;

public class UI_LoginBtn : MonoBehaviour
{
    public GameObject loginFailUI;
    public GameObject loginSuccessUI;

    public OnLogin onLogin;
    public OnUser onUser;
    
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern bool login();
#endif
    
    public void Run()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        login();
#else
        onLogin.OnLoginSuccess();
        onUser.OnBalance("10");
#endif
    }
}
