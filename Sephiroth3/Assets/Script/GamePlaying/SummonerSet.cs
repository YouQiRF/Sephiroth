using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerSet : MonoBehaviour
{
    [SerializeField] private int NumberA;
    [SerializeField] private int NumberB;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetInt("SummonerA",NumberA);
            PlayerPrefs.SetInt("SummonerB",NumberB);
            Debug.Log("IsSet!!!");
        }
    }
}
