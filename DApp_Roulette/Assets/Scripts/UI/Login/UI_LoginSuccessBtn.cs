using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LoginSuccessBtn : MonoBehaviour
{
    public GameObject loginUI;
    public void Run()
    {
        //원한다면 여기서 로그인 실패 메시지 바꿔줄 수 있음
        loginUI.SetActive(false);
    }
}
