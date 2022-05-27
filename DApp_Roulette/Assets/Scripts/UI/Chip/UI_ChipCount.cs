using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using System.Runtime.InteropServices;

public class UI_ChipCount : MonoBehaviour
{
    public TMP_Text chipCount;
    private BigInteger eth = 0;
    //Ĩ ����� ��������? �� �̴����ߵ���?
    //�ϴ� �� 10 �̴� ���ٰ� �����ϰ� ����

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string fromWei(string wei);
#endif
    
    public void init()
    {
        eth = GameManager.instance.GetUser().balance;
#if UNITY_WEBGL && !UNITY_EDITOR
        string ether = fromWei(eth.ToString());
        if (ether.Contains('.'))
        {
            int index = ether.IndexOf(".");
            int end = ether.Length; 
            ether = ether.Substring(0, index+5 > end ? end : index+5);
        }
        chipCount.text = ether;
#else
        chipCount.text = eth.ToString();
#endif
    }

    public void UpdateCnt(float _bettingValue)
    {
        // eth += _bettingValue;
        // chipCount.text = "x"+eth;
    }
}
