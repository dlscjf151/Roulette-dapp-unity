using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_LoginBtn : MonoBehaviour
{
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
        User user = new User( -1 );
        bool loginSucceed = false;
        
        if(true)
        {
            //[DApp1] metamask로 로그인
            //awiat 사용해도 되고 안해도 됩니다
            //실패하면 false return
        }

        GameManager.instance.SetUser(user);
        return loginSucceed;
    }
}
