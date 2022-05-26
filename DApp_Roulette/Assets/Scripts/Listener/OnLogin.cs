using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System.Numerics;

public class OnLogin : MonoBehaviour
{
    
    public GameObject loginFailUI;
    public GameObject loginSuccessUI;

    public void OnLoginSuccess() {
        User user = new User(new BigInteger(0), "");
        GameManager.instance.SetUser(user);
        loginSuccessUI.SetActive(true);
    }

    public void OnLoginFail() {
        loginFailUI.SetActive(true);
    }
}
