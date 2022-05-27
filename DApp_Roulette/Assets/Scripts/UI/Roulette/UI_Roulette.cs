using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Roulette : MonoBehaviour
{
    public Transform rollTarget;

    private void Update()
    {
        rollTarget.Rotate(new Vector3(0,0, 0.5f));
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
