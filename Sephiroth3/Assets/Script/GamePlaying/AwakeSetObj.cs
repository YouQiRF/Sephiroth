using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeSetObj : MonoBehaviour
{
    [SerializeField] private GameObject[] AllObjA;
    [SerializeField] private GameObject[] AllObjB;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("VAR");
        Instantiate(AllObjA[PlayerPrefs.GetInt("SummonerA")], this.transform);
        Instantiate(AllObjB[PlayerPrefs.GetInt("SummonerB")], this.transform);
    }
}
