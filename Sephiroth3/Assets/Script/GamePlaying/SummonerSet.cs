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
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerPrefs.SetInt("SummonerA",2);
            PlayerPrefs.SetInt("SummonerB",3);
            Debug.Log("IsSetA!!!");
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("SummonerA",2);
            PlayerPrefs.SetInt("SummonerB",1);
            Debug.Log("IsSetB!!!");
        }
    }
}
