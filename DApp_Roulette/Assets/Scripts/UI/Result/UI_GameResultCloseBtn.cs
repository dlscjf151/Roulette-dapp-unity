using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameResultCloseBtn : MonoBehaviour
{
    private GameManager gameManager;
    public UI_GameResultUI gameResultUI;
    public void Start()
    {
        gameManager = GameManager.instance;
    }

    public void Run()
    {
        //리워드 받고 베팅상태로 switch하기
        //리워드 창 말고 뭐 만지면 안됨 block UI 필요
        // RewardUI.Close하면 베팅 상태로 switch
        gameManager.SwitchGameStateToBetting();
        gameResultUI.gameObject.SetActive(false);
    }
}
