using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BettingErrorUICloseBtn : MonoBehaviour
{
    public GameObject targetUI;
    public void Close()
    {
        targetUI.SetActive(false);
    }
}
