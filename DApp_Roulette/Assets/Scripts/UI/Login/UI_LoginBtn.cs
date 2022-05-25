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
    
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern bool login();
#endif
    
    public void Run()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        login();
#else
        User user = new User(new BigInteger(10), "");
        GameManager.instance.SetUser(user);
        loginSuccessUI.SetActive(true);
#endif
    }
}
