using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
public class OnUser : MonoBehaviour
{
    public void OnBalance(string _balance)
    {
        User user = GameManager.instance.GetUser();
        user.balance = BigInteger.Parse(_balance);
        GameManager.instance.SetUser(user);
    }

    public void OnAddress(string _address)
    {
        User user = GameManager.instance.GetUser();
        user.address = _address;
        GameManager.instance.SetUser(user);
    }
}