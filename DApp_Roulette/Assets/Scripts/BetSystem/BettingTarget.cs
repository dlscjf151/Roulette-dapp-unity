using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettingTarget : MonoBehaviour
{

    public GameObject number = null;//�Ŀ� GameObject[]�� �ٲ㼭 ���� ����?

    int bettingType;
    public UI_Betting bettingUI;

	public void BetRed(){
		bettingType = 1;
		Run();
	}

	public void BetBlack(){
		bettingType = 2;
		Run();
	}

    public void Run()
    {
        Debug.Log(bettingType);
        // Debug.Assert(((bettingType == 0) || (bettingType ==1)), "Assert : betting type was [NONE]");
        bettingUI.Set(bettingType);
        bettingUI.gameObject.SetActive(true);
    }

}
