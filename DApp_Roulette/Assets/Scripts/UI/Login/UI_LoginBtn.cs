using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_LoginBtn : MonoBehaviour
{
    public TMP_InputField addressInputField;
    public GameObject loginFailUI;
    public GameObject loginSuccessUI;
    
    public void Run()
    {
        //로그인 실행
        if (TryLogIn()) //로그인 성공했으니 로그인 시스템 종료.
        {
            //현재는 로그아웃하여 다시 로그인 메뉴로 돌아올 수 없다.
            loginSuccessUI.SetActive(true);
        }
        else //로그인 실패
        {//로그인 실패 UI 보여주기
            loginFailUI.SetActive(true);
        }
    }

    private bool TryLogIn()
    {
        User user = new User("NONE", 0 );
        bool loginSucceed = false;

        if (addressInputField.text == "0")
        {//base 계정 로그인하기.
            user = new User("Joon", 100);
            loginSucceed = true;
        }
            
        
        if(true)
        {
            //[DApp1] 블록체인에서 정보를 받아와야됨.
            //실패하면 false return
        }

        GameManager.instance.SetUser(user);
        return loginSucceed;
    }
}
